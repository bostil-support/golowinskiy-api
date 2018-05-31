using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace GolovinskyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Authorization")]
    public class AuthorizationController : ControllerBase
    {
        IRepository repo;
        public AuthorizationController(IRepository r)
        {
            repo = r;
        }
        // GET: api/Authorization/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Authorization
        [HttpPost]
        public async Task Post([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Некорректные данные в запросе");
                return;
                //return BadRequest();
            }

            var identity = GetIdentity(model);
            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Не верный логин и пароль");
                return;
            }
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            
            var endcodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new 
            {
                access_token = endcodedJwt,
                username = identity.Name,
                role = identity.Claims.ElementAt(1).Value,
                user_id = identity.Claims.ElementAt(2).Value
            };

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings 
            {
                Formatting = Formatting.Indented 
            }));
            //else
            //{

                /* var res = repo.CheckWebPassword(model);
                if (res == 0)
                {
                    return Ok(new LoginSuccessModel
                    {
                        Result = res,
                        IsItBoss = false,
                        Message = "Авторизация не пройдена"
                    });
                }
                else if(res == model.Cust_ID_Main)
                {
                    return Ok(new LoginSuccessModel {
                        Result = res,
                        IsItBoss = true,
                        Message = "Вход осуществлен хозяином портала"
                    });
                }
                else
                {
                    return Ok(new LoginSuccessModel
                    {
                        Result = res,
                        IsItBoss = false,
                        Message = "Вход осуществлен пользователем портала"
                    });
                } */                
            //}             
        }
        
        // PUT: api/Authorization
        [HttpPut]
        public IActionResult Put([FromBody]RegisterInputModel model)
        {
            RegisterOutputModel regOutputModel = repo.AddWebCustomerCompany(model);
            if (!ModelState.IsValid)
                return BadRequest();
            if (regOutputModel.Cust_ID == 999999 && regOutputModel.AuthCode.Length == 0)
            {
                regOutputModel.Message = "Пользователь с таким email уже зарегистрирован";
                regOutputModel.Result = false;
                return Ok(regOutputModel);
            }
            return Ok(regOutputModel);
        }

        private ClaimsIdentity GetIdentity(LoginModel model)
        {
            var res = repo.CheckWebPassword(model);
                
            if (res != 0)
            {
                string role = res == model.Cust_ID_Main ? "admin" : "customer";
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, model.UserName),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, role),
                    new Claim("user_id", res.ToString())
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                    claims,
                    "Token",
                    ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType
                );
                return claimsIdentity;
            }

            return null;    
        }
    }
}
