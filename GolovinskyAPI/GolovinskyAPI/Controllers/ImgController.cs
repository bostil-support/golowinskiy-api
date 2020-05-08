using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Models;
using GolovinskyAPI.Models.ViewModels.Images;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolovinskyAPI.Controllers
{
    /// <summary>
    /// Контроллер для работы с картинками
    /// </summary>
    /// <returns></returns>
    //[Produces("application/json")]
    [Route("api/Img")]
    [DisableRequestSizeLimit]
    [DisableCors]
    public class ImgController : ControllerBase
    {

        IRepository repo;
        
        

        public ImgController(IRepository r)
        {
            
            repo = r;
        }

        /// <summary>
        /// Отобразить картинку
        /// </summary>
        // GET: api/Img/5
        [HttpGet]
        public IActionResult Get(string AppCode, string ImgFileName)
        {
            var res = repo.GetImageMobile(AppCode, ImgFileName);
            if (res != null)
            {
                //return Ok("data:image/jpeg;base64," + Convert.ToBase64String(res));
                return File(res, "image/jpeg;base64");
            }
            else
            {
                return BadRequest();
            }

        }

        /// <summary>
        /// Добавление картинки
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST: api/Img
        [HttpPost]
        public IActionResult Post([FromBody] SearchPictureInfoInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var res = repo.SearchPictureInfo(model);
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpPost("ImagesInfo")]
        public IActionResult ImagesInfo([FromBody] SearchPicturesInfoInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                List<SearchPictureInfoOutputModel> res = new List<SearchPictureInfoOutputModel>();
                var prcIds = repo.SearchPicture(new SearchPictureInputModel
                {
                    ID = model.CategoryId
                });
                foreach (var item in prcIds)
                {
                    var respart = repo.SearchPictureInfo(new SearchPictureInfoInputModel { AppCode = model.AppCode,Cust_ID = model.Cust_ID, Prc_ID = item.Prc_ID});
                    res.Add(respart);
                }
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        /// <summary>
        /// Изменение картинки
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("/api/img/upload")]
        //[Authorize]
        public IActionResult Upload([FromForm] NewUploadImageInput model)
        {
            Console.WriteLine();
            var ts = DateTime.Now;
            Console.WriteLine("upload request started" + ts.ToString());
            if (!ModelState.IsValid)
            {
                return BadRequest("параметры запроса некорректные");
            }
            bool res = repo.UploadPicture(model);
            Console.WriteLine("upload request ended " + (DateTime.Now - ts).TotalMilliseconds);
            return Ok(new { result = res });
        }

      

        /// <summary>
        /// Удаление картинки
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete("/api/img/")]
       // [Authorize]
        public IActionResult Delete([FromBody] SearchPictureInfoInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("параметры запроса некорректные");
            }
            bool res = repo.DeleteMainPicture(model);
            return Ok(new { result = res });
        }
        
    }
}

