using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolovinskyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Gallery")]
    [DisableCors]
    public class GalleryController : Controller
    {
        IRepository repo;
        public GalleryController(IRepository r)
        {
            repo = r;
        }

        /// <summary>
        /// Отобразить изображение?
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
