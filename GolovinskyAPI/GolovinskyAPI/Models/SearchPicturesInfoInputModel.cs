using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Models
{
    public class SearchPicturesInfoInputModel
    {
        public string CategoryId{ get; set; }
        public int Cust_ID { get; set; }
        public string AppCode { get; set; }
    }
}
