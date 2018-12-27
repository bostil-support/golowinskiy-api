using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Models.ViewModels.Products;
using GolovinskyAPI.Models;

namespace GolovinskyAPI.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        string connection = null;
        public ProductRepository(string conn)
        {
            connection = conn;
        }

        // добавление нового товара или частн. объявления
        public NewProductOutputModel InsertProduct(NewProductInputModel model)
        {
            //char res;
            NewProductOutputModel res;
            using (IDbConnection db = new SqlConnection(connection))
            {
                res = db.Query<NewProductOutputModel>("sp_SearchCreateAvito", new {Catalog = model.Catalog,Id=model.Id,Ctlg_Name=model.Ctlg_Name,
                    TArticle =model.TArticle, TName =model.TName, TDescription =model.TDescription,
                    TCost =model.TCost, TImageprev =model.TImageprev, Appcode =model.Appcode,
                    TypeProd =model.TypeProd, PrcNt = model.PrcNt, TransformMech = model.TransformMech, video =model.video, CID =model.CID},
                             commandType: CommandType.StoredProcedure).First();
            }      
            return res;
        }

        // редактирование товара или частн. объявления.
        public bool UpdateProduct(NewProductInputModel model)
        {
            char res;
            using (IDbConnection db = new SqlConnection(connection))
            {
                var resObj = db.Query<NewProductOutputModel>("sp_SearchUpdateAvito", new {Catalog = model.Catalog,Id=model.Id,Ctlg_Name=model.Ctlg_Name,
                    TArticle =model.TArticle, TName =model.TName, TDescription =model.TDescription,
                    TCost =model.TCost, TImageprev =model.TImageprev, Appcode =model.Appcode,
                    TypeProd =model.TypeProd, PrcNt = model.PrcNt, TransformMech = model.TransformMech, video =model.video, CID =model.CID},
                             commandType: CommandType.StoredProcedure).First();
                res = resObj.Result;
            }
           return (res == '1');
        }

        // удаление товара
        public bool DeleteProduct(DeleteProductInputModel model)
        {
            char res;
            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    var resObj = db.Query<NewProductOutputModel>("sp_SearchDeleteAvito", model,
                                 commandType: CommandType.StoredProcedure).First();
                    res = resObj.Result;
                }

                return (res == '1');
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //поиск товара 
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
        
        

    }
}
