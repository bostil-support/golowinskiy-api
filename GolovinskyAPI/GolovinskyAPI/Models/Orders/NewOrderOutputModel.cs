using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GolovinskyAPI.Models.Orders
{
    public class NewOrderOutputModel
    {
        //public string Ord_No { get; set; }
            
        public int? Ord_ID { get; set; }
        public bool Status { get; set; } = true;
    }
}