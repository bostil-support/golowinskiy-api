using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Models;
using GolovinskyAPI.Models.Orders;
using GolovinskyAPI.Models.ViewModels.Categories;
using GolovinskyAPI.Models.ViewModels.CustomerInfo;
using GolovinskyAPI.Models.ViewModels.Images;
using GolovinskyAPI.Models.ShopInfo;
using GolovinskyAPI.Models.ViewModels.Mobile;
using Microsoft.AspNetCore.Http;

namespace GolovinskyAPI.Infrastructure
{
    public interface IRepository
    {
       int GetCustId(int subdomain);
        List<SearchAvitoPictureOutput> SearchAvitoPicture(SearchAvitoPictureInput input);
        List<SearchPictureOutputModel> SearchPicture(SearchPictureInputModel input);
        byte[] GetImageMobile(string id, string name);
        SearchPictureInfoOutputModel SearchPictureInfo(SearchPictureInfoInputModel input);
        int CheckWebPassword(LoginModel input);
        RegisterOutputModel AddWebCustomerCompany(RegisterInputModel input);
        string[] RecoveryPassword(PasswordRecoveryInput input);
        NewOrderOutputModel AddNewOrder(NewOrderInputModel input);
        bool AddItemToCart(NewOrderItemInputModel input);
        
        List<SearchAvitoPictureOutput> GetCategoryItems(CategoriesInput input);
        bool ChangeQty(NewOrderItemInputModel input);
        bool SaveOrder(NewOrderShippingInputModel input);
        CustomerInfoPromoOutputModel CustomerInfoPromo(int? id);
        bool UploadPicture(NewUploadImageInput input);
        bool DeleteMainPicture(SearchPictureInfoInputModel input);
        bool InsertAdditionalPictureToProduct(NewAdditionalPictureInputModel input);
        bool UpdateAdditionalPictureToProduct(NewAdditionalPictureInputModel input);
        bool DeleteAdditionalPictureToProduct(DeleteAdditionalInputModel input);
        ShopInfo GetSubDomain(string url);
        bool AddInetMobileOrder(AddInetMobileOrdeModel input);
        List<OutMobileDbModel> GetMobileDB(GetMobileDbModel input);
        CustomerInfoOutput GetCustomerFIO(int CustID);
    }
}
