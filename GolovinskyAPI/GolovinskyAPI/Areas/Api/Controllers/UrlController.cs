using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Models.ShopInfo;
using GolovinskyAPI.Services;

namespace GolovinskyAPI.Areas.Api.Controllers
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
            
            var customizeService = new CustomizeService();
            string mainImage = customizeService.GetMainImage();
            string accountMainImage = customizeService.GetMainImageUserAccount();
            ShopInfo res = repo.GetSubDomain(url);
            if (res == null)
            {
                return Ok(new { 
                    Message = $"Извините, магазин {url}.головинский.рф не найден", 
                    MainPicture = $"/mainimages/{mainImage}",
                    MainPictureAccountUser = $"/accountImages/{accountMainImage}",
                Status = false });
            }
            res.MainPicture = $"/mainimages/{mainImage}";
            res.MainPictureAccountUser = $"/accountImages/{accountMainImage}";
            return Ok(new { 
                cust_id = res.cust_id, 
                mainImage = res.MainPicture,
                mainPictureAccountUser = res.MainPictureAccountUser });
        }
    }
}