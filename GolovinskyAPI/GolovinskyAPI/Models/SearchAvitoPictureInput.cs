using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Models
{
    public class SearchAvitoPictureInput
    {
        [BindRequired]
        public string Catalog { get; set; }
        [BindRequired]
        public string Table { get; set; }
        [BindRequired]
        public string Id { get; set; }
        [BindRequired]
        public string Cust_ID_Main { get; set; }
    }
}
