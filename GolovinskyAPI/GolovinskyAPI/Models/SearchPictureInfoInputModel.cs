using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Models
{
    public class SearchPictureInfoInputModel
    {
        public int Prc_ID { get; set; }
        public int Cust_ID { get; set; }
        public string AppCode { get; set; }
        // параметр, который должен будет передаваться при работе Системы частных объявлений
        //public int CID { get; set; } //не нужен(необязательное поле)
    }
}
