using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Models;
using GolovinskyAPI.Models.Orders;
using GolovinskyAPI.Models.ViewModels.Categories;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

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
        string RecoveryPassword(PasswordRecoveryInput input);
        NewOrderOutputModel AddNewOrder(NewOrderInputModel input);
        bool AddItemToCart(NewOrderItemInputModel input);
        
        List<SearchAvitoPictureOutput> GetCategoryItems(SearchAvitoPictureInput input);
        bool ChangeQty(NewOrderItemInputModel input);
        bool SaveOrder(NewOrderShippingInputModel input); 
    }
}
