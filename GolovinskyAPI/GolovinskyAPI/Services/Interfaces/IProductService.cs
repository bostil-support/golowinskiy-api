using GolovinskyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Services.Interfaces
{
    public interface IProductService
    {
        List<SearchPictureOutputModel> GetProductsByCategory(SearchPictureInputModel model);
    }
}
