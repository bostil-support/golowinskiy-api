using GolovinskyAPI.Models;
using GolovinskyAPI.Models.ViewModels.Products;
using System.Collections.Generic;

namespace GolovinskyAPI.Infrastructure.Administration
{
    public interface ITemplateRepository
    {
        bool UploadDatabaseFromtxt(UploadDBfromtxt upload);
      //  NewProductOutputModel InsertProduct(NewProductInputModel input);
       // bool UpdateProduct(NewProductInputModel input);
       // bool DeleteProduct(DeleteProductInputModel input);
       // List<SearchPictureOutputModel> SearchProduct(SearchPictureInputModel input);
    }
}