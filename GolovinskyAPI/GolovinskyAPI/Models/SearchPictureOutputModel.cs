using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Models
{
    public class SearchPictureOutputModel
    {
        public int Prc_ID { get; set; }
        public string Image_Site { get; set; }
        public string Image_Base { get; set; }
        public string AppCode { get; set; }
        public string Prc_Br { get; set; }
        public byte[] Img { get; set; }
        public string Suplier { get; set; }
        public string Cust_ID { get; set; }
        public string TName { get; set; }
        public string IsShowBasket { get; set; }
        public string gdate { get; set; }
    }
}
