using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GolovinskyAPI.Models.ViewModels.CustomerInfo;
using GolovinskyAPI.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace GolovinskyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/UserInfo")]
    [DisableCors]
    public class UserInfoController : ControllerBase
    {
        IRepository repo;
        public UserInfoController(IRepository r)
        {
            repo = r;
        }

        /// <summary>
        /// Отображение данных клиента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/UserInfo/5
        [HttpGet("{id}", Name = "UserInfo")]
        [Authorize]
        public IActionResult Get(int? id)
        {
            if (id == null)
            {
                return BadRequest("id пользователя не задан");
            }

            return Ok(repo.CustomerInfoPromo(id));
        }
    }
}
