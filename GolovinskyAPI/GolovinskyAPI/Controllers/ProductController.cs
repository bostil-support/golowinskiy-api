﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Models.ViewModels.Products;
using Microsoft.AspNetCore.Authorization;
using GolovinskyAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace GolovinskyAPI.Controllers
{
    /// <summary>
    /// Работа с товарами
    /// </summary>
    [Produces("application/json")]
    [Route("api/Product")]
    [DisableCors]
    public class ProductController : ControllerBase
    {
        IProductRepository repo;
        public ProductController(IProductRepository r)
        {
            repo = r;
        }

        // POST: api/Product
        /// <summary>
        /// Добавление нового товара
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
       // [Authorize]
        public IActionResult Post([FromBody] NewProductInputModel model)
        {
            var ts = DateTime.Now;
            Console.WriteLine();
            Console.WriteLine("Product Post request started" + ts.ToString());
            if (!ModelState.IsValid)
            {
                return BadRequest("Не верные параметры в запросе");
            }

            var res = repo.InsertProduct(model);
            Console.WriteLine("Product Post request ended " + (DateTime.Now - ts).TotalMilliseconds);
            return Ok(new { result = res.Result, prc_id = res.Prc_ID });
        }

        // PUT: api/Product/
        /// <summary>
        /// Изменение товара
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        //[Authorize]
        public IActionResult Put([FromBody] NewProductInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Не верные параметры в запросе");
            }

            bool res = repo.UpdateProduct(model);
            return Ok(new { result = res });
        }

        /// <summary>
        /// Удаление товара
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize]
        public IActionResult Delete([FromBody] DeleteProductInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Не верные параметры в запросе");
            }

            bool res = repo.DeleteProduct(model);
            return Ok(new { result = res });
        }


        
        /// <summary>
        /// Поиск продукта
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("/api/product/search/")]
        public IActionResult Search([FromBody] SearchPictureInputModel model )
        {
            if(!ModelState.IsValid)
            
                return BadRequest();
            
            return Ok(repo.SearchProduct(model));
        }




    }
}
