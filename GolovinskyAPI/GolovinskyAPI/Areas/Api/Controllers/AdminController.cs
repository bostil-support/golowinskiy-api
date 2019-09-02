using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Infrastructure.Administration;
using GolovinskyAPI.Models;
using GolovinskyAPI.Models.ViewModels.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolovinskyAPI.Areas.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с админкой
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    //[Route("api/Admin")]
    public class AdminController : ControllerBase
    {
        ITemplateRepository repo;

        public AdminController(ITemplateRepository r)
        {
            repo = r;
        }
        /// <summary>
        /// Отображение данных клиента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpGet("api/Admin/UserInfo")]
       
        public IActionResult Get(int? id)
        {
            if (id == null)
            {
                return BadRequest("id пользователя не задан");
            }

            return Ok(repo.CustomerInfoPromo(id));
        }
    
    // POST: api/Admin
    /// <summary>
    /// Загрузка txt документа в БД
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("api/Admin/Upload")]
        public IActionResult Upload([FromBody] UploadDBfromtxt model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("параметры запроса некорректные");
            }
            bool res = repo.UploadDatabaseFromtxt(model);
            return Ok(new { result = res });
        }
        // POST: api/Admin
        /// <summary>
        /// Просмотр информации о товаре
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("api/Admin/GetInfo")]
        public IActionResult GetInfo([FromBody] SearchPictureInfoInputModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var res = repo.SearchPictureInfo(model);
                if(res!=null)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest();
                }
            }
        }
        // POST: api/Admin
        /// <summary>
        /// поиск товара
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("api/Admin/Search")]
        public IActionResult Search([FromBody] SearchPictureInputModel model)
        {
            if(ModelState.IsValid)
            {
                return Ok(repo.SearchProduct(model));
                
            }
            else
            {
                return BadRequest();
            }
        }
    }
}