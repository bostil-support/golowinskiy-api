using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Post([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var res = repo.CheckWebPassword(model);
                if (res == 0)
                {
                    return BadRequest("Авторизация не пройдена");
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
                }                
            }             
        }
        
        // PUT: api/Authorization
        [HttpPut]
        public IActionResult Put([FromBody]RegisterInputModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(repo.AddWebCustomerCompany(model));

        }
    }
}
