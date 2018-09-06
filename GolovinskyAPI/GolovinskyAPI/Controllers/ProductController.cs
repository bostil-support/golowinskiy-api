using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Models.ViewModels.Products;
using Microsoft.AspNetCore.Authorization;

namespace GolovinskyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : ControllerBase
    {
        IProductRepository repo;
        public ProductController(IProductRepository r)
        {
            repo = r;
        }

        // POST: api/Product
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] NewProductInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Не верные параметры в запросе");
            }

            bool res = repo.InsertProduct(model);
            return Ok(new { result = res });
        }
        
        // PUT: api/Product/
        [HttpPut]
        [Authorize]
        public IActionResult Put([FromBody] NewProductInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Не верные параметры в запросе");
            }

            bool res = repo.UpdateProduct(model);
            return Ok(new { result = res });
        }
        
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
    }
}
