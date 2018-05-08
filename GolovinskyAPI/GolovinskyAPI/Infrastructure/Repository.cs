using Dapper;
using GolovinskyAPI.Models;
using GolovinskyAPI.Models.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace GolovinskyAPI.Infrastructure
{
    public class Repository : IRepository
    {
        string connection = null;
        public Repository(string conn)
        {
            connection = conn;
        }

        public int GetCustId(int subdomain)
        {
            int res = 0;
            using (IDbConnection db = new SqlConnection(connection))
            {
                var resObj = db.Query<GuestCastIDModel>("sp_GetGuestCustID", new { Cust_ID_Main = subdomain },
                             commandType: CommandType.StoredProcedure).First();
                res = resObj.Cust_ID;
            }
            return res;
        }

        public List<SearchAvitoPictureOutput> SearchAvitoPicture(SearchAvitoPictureInput input)
        {
            var res = new List<SearchAvitoPictureOutput>();
            using (IDbConnection db = new SqlConnection(connection))
            {
                res = db.Query<SearchAvitoPictureOutput>("sp_SearchAvitoPicture", new { Catalog = input.Catalog, Table = input.Table, Id = input.Id, Cust_ID_Main = input.Cust_ID_Main },
                             commandType: CommandType.StoredProcedure).ToList();
            }
            return res;
        }

        public List<SearchPictureOutputModel> SearchPicture(SearchPictureInputModel input)
        {
            var res = new List<SearchPictureOutputModel>();
            using (IDbConnection db = new SqlConnection(connection))
            {
                //res = db.Query<SearchPictureOutputModel>("sp_SearchPicture", new { SearchDescr = input.SearchDescr, Cust_ID = input.Cust_ID, Suplier = input.Suplier, ID = input.ID, Option = input.Option, Ctlg_Name = input.Ctlg_Name, Ctlg_No = input.Ctlg_No, CID = input.CID },
                //             commandType: CommandType.StoredProcedure).ToList();
                res = db.Query<SearchPictureOutputModel>("sp_SearchPicture", new { SearchDescr = input.SearchDescr, Cust_ID = input.Cust_ID, ID = input.ID }, commandType: CommandType.StoredProcedure).ToList();
            }
            return res;
        }

        //ПРОЦЕДУРА НЕ РАБОТАЕТ
        public byte[] GetImageMobile(string id, string name)
        {
            var res = new byte[0];
            using (IDbConnection db = new SqlConnection(connection))
            {
                var resObj = db.Query<byte[]>("sp_GetImageMobile", new { AppCode  = id, img_filename = name},
                             commandType: CommandType.StoredProcedure).First();
                res = resObj;
            }
            return res;
        }

        public SearchPictureInfoOutputModel  SearchPictureInfo(SearchPictureInfoInputModel input)
        {
            var res = new SearchPictureInfoOutputModel();
            List<Image> additionalOutputImage = new List<Image>();

            using (IDbConnection db = new SqlConnection(connection))
            {
                res = db.Query<SearchPictureInfoOutputModel>("sp_SearchPictureInfo", new { Prc_ID = input.Prc_ID, Cust_ID = input.Cust_ID, AppCode = input.AppCode},
                             commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

             additionalOutputImage = this.GetAllAdditionalPictures(input);

            res.additionalImages = additionalOutputImage;
            
            return res;
        }

        private List<Image> GetAllAdditionalPictures(SearchPictureInfoInputModel input)
        {
            List<Image> list = new List<Image>();
            
            using (IDbConnection db = new SqlConnection(connection))
            {
                //search additional images
                list = db.Query<Image>("sp_SearchGetAvitoAddImage", new { Prc_ID = input.Prc_ID, Cust_ID = input.Cust_ID, AppCode = input.AppCode },
                    commandType: CommandType.StoredProcedure).ToList();//.to<AdditionalOutputImage>(); //.All<AdditionalOutputImage>();
            }

            return list;
        }

        public int CheckWebPassword(LoginModel input)
        {
            var res = 0;
            using (IDbConnection db = new SqlConnection(connection))
            {
                var p = new DynamicParameters();
                p.Add("@UserName", input.UserName);
                p.Add("@Password", input.Password);
                p.Add("@Cust_ID_Main", input.Cust_ID_Main);
                p.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var procRes = db.Execute("sp_CheckWebPassword", p,
                             commandType: CommandType.StoredProcedure);
                res = p.Get<int>("@Result");

            }
            return res;
        }

        public RegisterOutputModel AddWebCustomerCompany(RegisterInputModel input)
        {
            var res = new RegisterOutputModel();
            using (IDbConnection db = new SqlConnection(connection))
            {

                var p = new DynamicParameters();
                p.Add("@password", input.password);
                p.Add("@Phone1", input.Phone1);
                p.Add("@Mobile", input.Mobile);
                p.Add("@f", input.f);
                p.Add("@e_mail", input.e_mail);
                p.Add("@Cust_ID_Main", input.Cust_ID_Main);
                p.Add("@Cust_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@Comp_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@AuthCode", dbType: DbType.String, direction: ParameterDirection.Output);
                p.Add("@AuthPass", dbType: DbType.String, direction: ParameterDirection.Output);
                var procRes = db.Execute("sp_AddWebCustomerCompany", p,
                             commandType: CommandType.StoredProcedure);
                res = new RegisterOutputModel
                {
                    Cust_ID = p.Get<int>("@Cust_ID"),
                    Comp_ID = p.Get<int>("@Comp_ID"),
                    AuthCode = p.Get<string>("@AuthCode"),
                    AuthPass = p.Get<string>("@AuthPass")
                };

            }
            return res;
        }
    }
}
