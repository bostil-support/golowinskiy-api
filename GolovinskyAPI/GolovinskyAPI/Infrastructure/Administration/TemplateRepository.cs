using Dapper;
using GolovinskyAPI.Models;
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
        
    }
}