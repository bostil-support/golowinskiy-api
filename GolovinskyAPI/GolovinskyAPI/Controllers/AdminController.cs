using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Infrastructure.Administration;
using GolovinskyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolovinskyAPI.Controllers
{
    //[Produces("application/json")]
    [Route("api/Admin")]
    public class AdminController : ControllerBase
    {
        ITemplateRepository repo;

        public AdminController(ITemplateRepository r)
        {
            repo = r;
        }
        [HttpPost]
        public IActionResult Upload([FromBody] UploadDBfromtxt model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("параметры запроса некорректные");
            }
            bool res = repo.UploadDatabaseFromtxt(model);
            return Ok(new { result = res });
        }
    }
}