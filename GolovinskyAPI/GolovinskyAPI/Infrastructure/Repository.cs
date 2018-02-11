using Dapper;
using GolovinskyAPI.Models;
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

        public List<SearchAvitoPictureOutput> SearchAvitoPicture (SearchAvitoPictureInput input)
        {
            var res = new List<SearchAvitoPictureOutput>();
            using (IDbConnection db = new SqlConnection(connection))
            {
                res = db.Query<SearchAvitoPictureOutput>("sp_SearchAvitoPicture", new {Catalog = input.Catalog, Table = input.Table, Id = input.Id, Cust_ID_Main = input.Cust_ID_Main} ,
                             commandType: CommandType.StoredProcedure).ToList();
            }
            return res;
        }

    }
}
