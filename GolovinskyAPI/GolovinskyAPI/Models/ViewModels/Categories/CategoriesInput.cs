using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Models.ViewModels.Categories
{
    public class CategoriesInput
    {
        //id магазина
        public string Cust_ID_Main { get; set; }
        //id пользователя, передается для вывода категорий конкретного пользователя
        public int? CID { get; set; }
        
        public char? advert { get; set; }

        //Id авторизованноо клиента
        public int? Cust_Id { get; set; }
    }
}
