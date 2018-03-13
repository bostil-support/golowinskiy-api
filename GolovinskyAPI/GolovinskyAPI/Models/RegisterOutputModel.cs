using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Models
{
    public class RegisterOutputModel
    {
        public int Cust_ID { get; set; }
        public int Comp_ID { get; set; }
        public string AuthCode { get; set; }
        public string AuthPass { get; set; }
    }
}
