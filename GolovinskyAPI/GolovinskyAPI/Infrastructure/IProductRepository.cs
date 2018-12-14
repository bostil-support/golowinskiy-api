using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Models.ViewModels.Products;

namespace GolovinskyAPI.Infrastructure
{
    public interface IProductRepository
    {
        NewProductOutputModel InsertProduct(NewProductInputModel input);
        bool UpdateProduct(NewProductInputModel input);
        bool DeleteProduct(DeleteProductInputModel input);
    }
}
