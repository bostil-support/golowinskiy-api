using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Models.ViewModels.Images;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolovinskyAPI.Controllers
{
    /// <summary>
    /// Дополнительная картинка к товару
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    [Route("api/AdditionalImg")]
    public class AdditionalImgController : ControllerBase
    {
        IRepository repo;
        public AdditionalImgController(IRepository r)
        {
            repo = r;
        }

        /// <summary>
        /// Добавление дополнительной картинки
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST: api/AdditionalImg
        [HttpPost]
        //[Authorize]
        public IActionResult Post([FromBody] NewAdditionalPictureInputModel model)
        {
            var ts = DateTime.Now;
            Console.WriteLine();
            Console.WriteLine("AdditionalImg request started" + ts.ToString());
            if (!ModelState.IsValid)
            {
                return BadRequest( new { result = false, message = "Не корректный запрос"});
            }
            var res = repo.InsertAdditionalPictureToProduct(model);
            Console.WriteLine("AdditionalImg request ended " + (DateTime.Now - ts).TotalMilliseconds);
            return Ok(res);
        }

        /// <summary>
        /// Изменение дополнительной картинки
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // PUT: api/AdditionalImg/
        [HttpPut("api/AdditionalImg/")]
        public IActionResult Put([FromBody] NewAdditionalPictureInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { result = false, message = "Не корректный запрос" });
            }
            return Ok(repo.UpdateAdditionalPictureToProduct(model));
        }

        /// <summary>
        /// Удаление дополнительной картикни
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // DELETE: api/AdditionalImg/
        [HttpDelete("api/AdditionalImg/")]
        public IActionResult Delete([FromBody] DeleteAdditionalInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { result = false, message = "Не корректный запрос" });
            }
            return Ok(new { result = repo.DeleteAdditionalPictureToProduct(model) });
        }
    }
}
