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
    [Route("api/Gallery")]
    public class GalleryController : Controller
    {
        IRepository repo;
        public GalleryController(IRepository r)
        {
            repo = r;
        }
        // POST: api/SearchPicture
        [HttpPost]
        public IActionResult Post([FromBody] SearchPictureInputModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(repo.SearchPicture(model));
        }
    }
}
