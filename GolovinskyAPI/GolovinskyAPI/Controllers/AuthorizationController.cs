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
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;
using GolovinskyAPI.Services;

namespace GolovinskyAPI.Controllers
{
    /// <summary>
    /// Авторизация
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    [Route("api/Authorization")]
    public class AuthorizationController : ControllerBase
    {
        IRepository repo;
        private readonly IOptions<AuthServiceModel> _options;
        public AuthorizationController(IRepository r, IOptions<AuthServiceModel> options)
        {
            _options = options;
            repo = r;
        }

        // POST: api/Authorization
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                //Response.StatusCode = 400;
                //await Response.WriteAsync("Некорректные данные в запросе");
                //return;
                return BadRequest("Некорректные данные в запросе");
            }

            var identity = GetIdentity(model);
            if (identity == null)
            {
                //Response.StatusCode = 400;
                //await Response.WriteAsync("Не верный логин и пароль");
                return NotFound(new { result = false, message = "Не верный логин и пароль" });
            }
            var now = DateTime.UtcNow;

            var custInfo = repo.GetCustomerFIO(Convert.ToInt32(identity.Claims.ElementAt(2).Value));
            string fio = null;
            if(custInfo!= null) fio = custInfo.FIO;
            
            var jwt = new JwtSecurityToken(
                issuer: _options.Value.Issuer,
                audience: GetAUDIENCE(),
                notBefore: now,
                claims: identity.Claims,
              //  expires: now.Add(TimeSpan.FromMinutes(_options.Value.LifeTime)),
                expires: now.AddMonths(1),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(_options), SecurityAlgorithms.HmacSha256));
            
            var endcodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new LoginSuccessModel
            {
                AccessToken = endcodedJwt,
                UserName = identity.Name,
                FIO = fio,
                Phone = custInfo.Phone,
                Role = identity.Claims.ElementAt(1).Value,
                UserId = identity.Claims.ElementAt(2).Value
            };

            /* Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings 
            {
                Formatting = Formatting.Indented 
            })); */
            return Ok(response);
        }
        
        [NonAction]
        public string GetAUDIENCE()
        {
            var f = Request.GetDisplayUrl();
            return f;
        }

        // PUT: api/Authorization
        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
