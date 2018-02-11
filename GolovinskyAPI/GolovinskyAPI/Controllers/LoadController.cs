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
    [Route("api/Load")]
    public class LoadController : ControllerBase
    {
        IRepository repo;
        public LoadController(IRepository r)
        {
            repo = r;
        }

        // GET: api/Load/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var res = repo.GetCustId(id);
            return Ok(res);
        }

        // POST: api/Load
        [HttpPost]
        public IActionResult Post([FromBody] SearchAvitoPictureInput model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(repo.SearchAvitoPicture(model));
        }
    }
}
