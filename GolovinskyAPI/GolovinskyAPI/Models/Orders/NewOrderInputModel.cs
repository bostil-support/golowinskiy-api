using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GolovinskyAPI.Models.Orders
{
    public class NewOrderInputModel
    {
        //id пользователя
         public int Cust_ID { get; set; }
        //код валюты
        public int Cur_Code { get; set; } = 840;
    }
}