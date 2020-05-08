using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GolovinskyAPI.Models.ViewModels.Categories;
using GolovinskyAPI.Models.ViewModels.Mobile;
using Microsoft.AspNetCore.Cors;

namespace GolovinskyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Load")]
    [DisableCors]
    public class LoadController : ControllerBase
    {
        IRepository repo;
        public LoadController(IRepository r)
        {
            repo = r;
        }


        /// <summary>
        /// Переход в конкретный магазин
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
            //string route = "http://" + model.Id.ToString() + "." + "golowinskiy.bostil.ru/";
            //Console.WriteLine(route);
            //return Redirect(route);
            return Ok(repo.SearchAvitoPicture(model));
        }

        /// <summary>
        /// Получение категорий магазина
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //POST: api/categories
        [HttpPost("/api/categories/")]
        public IActionResult GetCategories([FromBody] CategoriesInput model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            CategoryRecursion catRecursion = new CategoryRecursion();
            List<SearchAvitoPictureOutput> outputCategories = repo.GetCategoryItems(model);   
            
            return Ok(catRecursion.GenerateCategories(outputCategories));
        }

        [HttpPost("/api/getMobileDB/")]
        public IActionResult GetMobileDB([FromBody] GetMobileDbModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(repo.GetMobileDB(model));
        }

        [HttpPut("/api/addInetMobileOrder/")]
        public IActionResult AddInetMobileOrder([FromBody] AddInetMobileOrdeModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(repo.AddInetMobileOrder(model));
        }
    }
}
