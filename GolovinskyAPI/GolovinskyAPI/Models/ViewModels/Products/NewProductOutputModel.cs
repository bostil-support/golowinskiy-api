using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Models.ViewModels.Products
{
    public class NewProductOutputModel
    {
        public char Result { get; set; } = '0';
        public string Prc_ID { get; set; }
        public string Suplier { get; set; }
        public string Cost { get; set; }
    }
}
