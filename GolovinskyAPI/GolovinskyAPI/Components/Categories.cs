using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GolovinskyAPI.Services;
using GolovinskyAPI.Models.ViewModels.Categories;
using GolovinskyAPI.Services.Interfaces;

namespace GolovinskyAPI.Components
{
    public class Categories : ViewComponent
    {
        private ICategoryService _categoryService;
        public Categories(ICategoryService catService)
        {
            _categoryService = catService;
        }

        public IViewComponentResult Invoke(string storeId)
        {
            List<SearchAvitoPictureOutput> categories = _categoryService.GetCategories(new CategoriesInput { Cust_ID_Main = storeId});
            return View("Categories", categories);
        }
    }
}
