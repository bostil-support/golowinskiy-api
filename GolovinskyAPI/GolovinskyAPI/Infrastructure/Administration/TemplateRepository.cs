using Dapper;
using GolovinskyAPI.Models;
using GolovinskyAPI.Models.ViewModels.CustomerInfo;
using GolovinskyAPI.Models.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GolovinskyAPI.Infrastructure.Administration
{
    public class TemplateRepository : ITemplateRepository
    {
        string connection = null;
        IDbConnection dbConnection;

        public TemplateRepository(string conn)
        {
            connection = conn;
            dbConnection = new SqlConnection(connection);
        }

        

        public SearchPictureInfoOutputModel SearchPictureInfo(SearchPictureInfoInputModel input)
        {
            var res = new SearchPictureInfoOutputModel();
            using (IDbConnection db = new SqlConnection(connection))
            {
                res = db.Query<SearchPictureInfoOutputModel>("sp_SearchPictureInfo",
                   new { Prc_ID = input.Prc_ID, Cust_ID = input.Cust_ID, AppCode = input.AppCode },
                            commandType: CommandType.StoredProcedure).FirstOrDefault();

            }
            if(res!=null)
            {
                res.AdditionalImages = this.GetAllAdditionalPictures(input);
                res.Prc_ID = input.Prc_ID;
                return res;
            }
            else
            {
                return null;
            }
        }
        private List<Models.Entities.Image> GetAllAdditionalPictures(SearchPictureInfoInputModel input)
        {
            List<Models.Entities.Image> list = new List<Models.Entities.Image>();

            using (IDbConnection db = new SqlConnection(connection))
            {
               
                list = db.Query<Models.Entities.Image>("sp_SearchGetAvitoAddImage", new { Prc_ID = input.Prc_ID, Cust_ID = input.Cust_ID, AppCode = input.AppCode },
                    commandType: CommandType.StoredProcedure).ToList();
            }

            return list;
        }

        public bool UploadDatabaseFromtxt(UploadDBfromtxt input)
        {
            try
            {
                string result;
                using (dbConnection)
                {
                    result = dbConnection.Query<string>("sp_UpdateMobileDBfromTxtFiles", input, 
                        commandType: CommandType.StoredProcedure).First();
                }
                return result == "1";
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public List<SearchPictureOutputModel> SearchProduct(SearchPictureInputModel input)
        {
            List<SearchPictureOutputModel> response = new List<SearchPictureOutputModel>();
            using (IDbConnection db = new SqlConnection(connection))
            {
                response = db.Query<SearchPictureOutputModel>("sp_SearchPicture",
                    new { SearchDescr = input.SearchDescr, Cust_ID = input.Cust_ID },
                    commandType: CommandType.StoredProcedure).ToList();

            }


            return response;
        }

        public CustomerInfoPromoOutputModel CustomerInfoPromo(int? cust_id)
        {
            CustomerInfoPromoOutputModel result;
            using (SqlConnection db = new SqlConnection(connection))
            {
                result = db.Query<CustomerInfoPromoOutputModel>("sp_GetCustomerInfoPromo", new { Cust_ID = cust_id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;
        }
    }
}