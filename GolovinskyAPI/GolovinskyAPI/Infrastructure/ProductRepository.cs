using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Models.ViewModels.Products;

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
        public bool InsertProduct(NewProductInputModel model)
        {
            char res;
            using (IDbConnection db = new SqlConnection(connection))
            {
                var resObj = db.Query<NewProductOutputModel>("sp_SearchCreateAvito", model,
                             commandType: CommandType.StoredProcedure).First();
                res = resObj.Result;
            }      
        
             return (res == '1');
        }

        // редактирование товара или частн. объявления.
        public bool UpdateProduct(NewProductInputModel model)
        {
            char res;
            using (IDbConnection db = new SqlConnection(connection))
            {
                var resObj = db.Query<NewProductOutputModel>("sp_SearchUpdateAvito", model,
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
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
