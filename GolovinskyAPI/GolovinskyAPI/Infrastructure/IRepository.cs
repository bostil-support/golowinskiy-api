using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Models;

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
    }
}
