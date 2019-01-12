using GolovinskyAPI.Models;
using GolovinskyAPI.Models.ViewModels.Products;
using System.Collections.Generic;

namespace GolovinskyAPI.Infrastructure.Administration
{
    public interface ITemplateRepository
    {
        bool UploadDatabaseFromtxt(UploadDBfromtxt upload);
        
    }
}