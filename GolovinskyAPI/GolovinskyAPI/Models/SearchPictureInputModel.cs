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
        public string SearchDescr { get; set; } = null;
        [BindRequired]
        public int Cust_ID { get; set; }
        [BindRequired]
        public string Suplier { get; set; } = "";
        [BindRequired]
        public string  ID { get; set; }
        [BindRequired]
        public int Option { get; set; } = 0;
        [BindRequired]
        public string Ctlg_Name { get; set; } = null;
        [BindRequired]
        public string Ctlg_No { get; set; } = null;
        [BindRequired]
        public int? CID { get; set; } = null;
    }

    public class PageIngoInput
    {
        /// <summary>
        /// номер страницы
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// записей на странице
        /// </summary>
        public int CountOnPage { get; set; }
    }
    public class PageInfoOutput
    {
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
        public int CountOnPage { get; set; }
    }
}
