using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Models;
using GolovinskyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GolovinskyAPI.Controllers
{
    [Route("products")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService prodService)
        {
            _productService = prodService;
        }

        [HttpGet("{storeId}/{categoryId}")]
        public IActionResult Index(int storeId, string categoryId)
        {
            if (!ModelState.IsValid)
              return BadRequest();

            var products = _productService.GetProductsByCategory(new SearchPictureInputModel { Cust_ID = storeId, ID = categoryId});
            return View(products);
        }
    }
}
