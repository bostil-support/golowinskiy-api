using GolovinskyAPI.Models;
using GolovinskyAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Services.Interfaces;

namespace GolovinskyAPI.Services
{
    public class ProductService : IProductService
    {
        private IRepository _repository;
        public ProductService(IRepository rep)
        {
            _repository = rep;
        }

        public List<SearchPictureOutputModel> GetProductsByCategory(SearchPictureInputModel model)
        {
            return _repository.SearchPicture(model);
        }
    }
}
