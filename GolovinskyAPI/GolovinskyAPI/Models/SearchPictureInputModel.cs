using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Models
{
    public class SearchPictureInputModel
    {
        [BindRequired]
        public string SearchDescr { get; set; }
        [BindRequired]
        public int Cust_ID { get; set; }
        [BindRequired]
        public string Suplier { get; set; }
        [BindRequired]
        public string  ID { get; set; }
        [BindRequired]
        public int  Option { get; set; }
        [BindRequired]
        public string Ctlg_Name { get; set; }
        [BindRequired]
        public string Ctlg_No { get; set; }
        [BindRequired]
        public string CID { get; set; }
    }
}
