using GolovinskyAPI.Models.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        List<SearchAvitoPictureOutput> GetCategories(CategoriesInput model);
    }
}
