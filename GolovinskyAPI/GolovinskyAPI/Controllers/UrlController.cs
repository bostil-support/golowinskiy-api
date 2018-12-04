using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Models.ShopInfo;

namespace GolovinskyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/shopinfo")]
    public class UrlController : ControllerBase
    {
        IRepository repo;
        public UrlController(IRepository r)
        {
            repo = r;
        }

        /// <summary>
        /// Отображение информации о магазине
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [HttpGet("{url}")]
        public IActionResult Get(string url)
        {
            ShopInfo res = repo.GetSubDomain(url);
            if (res == null)
            {
                return Ok(new { Message = "Не верный поддомен магазина", Status = false });
            }
            return Ok(new { cust_id = res.cust_id });
        }
    }
}