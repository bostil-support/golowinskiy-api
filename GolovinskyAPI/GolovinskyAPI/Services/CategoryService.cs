using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Models.ViewModels.Categories;
using GolovinskyAPI.Services.Interfaces;
using System.Collections.Generic;


namespace GolovinskyAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private IRepository _repository;

        public CategoryService(IRepository rep)
        {
            _repository = rep;
        }

        public List<SearchAvitoPictureOutput> GetCategories(CategoriesInput model)
        {
            List<SearchAvitoPictureOutput> categories;
            CategoryRecursion catRecursion = new CategoryRecursion();
            List<SearchAvitoPictureOutput> outputCategories = _repository.GetCategoryItems(model);

            categories = catRecursion.GenerateCategories(outputCategories);
            return categories;
        }
    }
}
