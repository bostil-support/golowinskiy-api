using Dapper;
using GolovinskyAPI.Models;
using GolovinskyAPI.Models.Entities;
using GolovinskyAPI.Models.Orders;
using GolovinskyAPI.Models.ViewModels.Categories;
using GolovinskyAPI.Models.ViewModels.CustomerInfo;
using GolovinskyAPI.Models.ViewModels.Images;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using GolovinskyAPI.Models.ShopInfo;
using System.Drawing;

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace GolovinskyAPI.Infrastructure.Administration
{
    public interface ITemplateRepository
    {
        bool UploadDatabaseFromtxt(UploadDBfromtxt upload);
        SearchPictureInfoOutputModel SearchPictureInfo(SearchPictureInfoInputModel input);
        List<SearchPictureOutputModel> SearchProduct(SearchPictureInputModel input);
        CustomerInfoPromoOutputModel CustomerInfoPromo(int? id);

    }
}