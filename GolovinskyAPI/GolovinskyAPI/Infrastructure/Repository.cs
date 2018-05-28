using Dapper;
using GolovinskyAPI.Models;
using GolovinskyAPI.Models.Entities;
using GolovinskyAPI.Models.Orders;
using GolovinskyAPI.Models.ViewModels.Categories;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
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
        private List<SearchAvitoPictureOutput> categories = new List<SearchAvitoPictureOutput>();
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

        //get all menu items
        public List<SearchAvitoPictureOutput> GetCategoryItems(SearchAvitoPictureInput input)
        {
            var categoryList = new List<SearchAvitoPictureOutput>();
            
            using (IDbConnection db = new SqlConnection(connection))
            {
                categoryList = db.Query<SearchAvitoPictureOutput>("sp_SearchAvitoPictureAll", new {
                    Cust_ID_Main = input.Cust_ID_Main 
                }, commandType: CommandType.StoredProcedure).ToList();
            }                
            return categoryList;
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

            res.AdditionalImages = additionalOutputImage;
            
            return res;
        }

        private List<Image> GetAllAdditionalPictures(SearchPictureInfoInputModel input)
        {
            List<Image> list = new List<Image>();
            
            using (IDbConnection db = new SqlConnection(connection))
            {
                //search additional images
                list = db.Query<Image>("sp_SearchGetAvitoAddImage", new { Prc_ID = input.Prc_ID, Cust_ID = input.Cust_ID, AppCode = input.AppCode },
                    commandType: CommandType.StoredProcedure).ToList();
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
                p.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 50);
                var procRes = db.Execute("sp_CheckWebPassword", p,
                             commandType: CommandType.StoredProcedure);
                res = p.Get<int>("@Result");

            }
            return res;
        }

        public string RecoveryPassword(PasswordRecoveryInput input)
        {
            string res;
            using (IDbConnection db = new SqlConnection(connection))
            {
                res = db.Query<string>("sp_RecoveryPassword", new { E_mail = input.EMail },
                                commandType: CommandType.StoredProcedure).FirstOrDefault();               
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
                p.Add("@AuthCode", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
                p.Add("@AuthPass", dbType: DbType.String, direction: ParameterDirection.Output, size: 20);
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

        public NewOrderOutputModel AddNewOrder(NewOrderInputModel input)
        {
            var result = new NewOrderOutputModel();
            dynamic count_id;
            
            using (IDbConnection db = new SqlConnection(connection))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@Cust_ID", input.Cust_ID);
                p.Add("@Cur_Code", input.Cur_Code);
                p.Add("@Ord_ID", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 10);
                p.Add("@Ord_No", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
            
                var res = db.Execute("sp_AddNewOrder", p, commandType: CommandType.StoredProcedure);
                            
                result = new NewOrderOutputModel
                {
                    Ord_ID = p.Get<int?>("@Ord_ID"),
                    Ord_No = p.Get<dynamic>("@Ord_No")
                };
            }
            return result;
        }

        public bool AddItemToCart(NewOrderItemInputModel input)
        {
            string res;
            using (IDbConnection db = new SqlConnection(connection))
            {
                res = db.Query<string>("sp_AddNewOrdItem", new { 
                        OrdTtl_Id= input.OrdTtl_Id,  
                        OI_No = input.OI_No,
                        Ctlg_No = input.Ctlg_No,
                        Qty = input.Qty,
                        Ctlg_Name = input.Ctlg_Name,
                        Sup_ID = input.Sup_ID,
                        Descr = input.Descr
                    },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            if (res != "1")       
                return false;
            return true;    
        }

        /* Для изменения количества по позициям, чтобы обезопасить себя от отключения от канала 
        интернета может быть применена процедура, которая сразу меняет количество в базе, 
        причем, если параметр @NewQty сделать равным 0, то позиция из базы удаляется автоматически. 
        */
        public bool ChangeQty(NewOrderItemInputModel input)
        {
            bool res;
            using (IDbConnection db = new SqlConnection(connection))
            {
                res = db.Query<bool>("sp_ChangeQty", new { 
                        Ord_ID= input.OrdTtl_Id,  
                        OI_No = input.OI_No,
                        NewQty = input.Qty,
                    },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return res;    
        }

        public bool SaveOrder(NewOrderShippingInputModel input)
        {
            string res;
            using (IDbConnection db = new SqlConnection(connection))
            {
                res = db.Query<string>("sp_OrderAsSMS", input,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            if (res.Length == 0)       
                return false;
            return true;
        }
    }
}
