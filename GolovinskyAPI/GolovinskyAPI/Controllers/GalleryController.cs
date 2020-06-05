using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            var res = repo.SearchPicture(model);
            
            return Ok(res);
        }
        /// <summary>
        /// Отобразить изображение?
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST: api/SearchPicture
        [Route ("Filter")]
        [HttpPost]
        public IActionResult PostFiltered([FromBody] SearchPictureInputModel model, PageIngoInput pageInfo)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (pageInfo.CountOnPage <= 0) pageInfo.CountOnPage = 15;
            if (pageInfo.PageNumber == 0) pageInfo.PageNumber = 1;
            var res = repo.SearchPicture(model);
            var totalPages = (int)(res.Count() / pageInfo.CountOnPage) + 1;
            if (totalPages < pageInfo.PageNumber) pageInfo.PageNumber = totalPages;
            PageInfoOutput pageInfoOutput = new PageInfoOutput
            {
                CountOnPage = pageInfo.CountOnPage,
                PageNumber = pageInfo.PageNumber,
                TotalPages = totalPages
            };
            res = res.Skip((pageInfo.PageNumber - 1) * pageInfo.CountOnPage).Take(pageInfo.CountOnPage).ToList();

            return Ok(new { res, pageInfoOutput });
        }
    }
}
