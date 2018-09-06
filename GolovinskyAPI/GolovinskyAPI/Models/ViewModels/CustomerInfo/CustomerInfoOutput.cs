using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Models.ViewModels.CustomerInfo
{
    public class CustomerInfoOutput
    {
        public string FIO { get; set; }
        public string Company { get; set; }
        public string Address  { get; set; }
        public string Phone  { get; set; }
        public string E_mail { get; set; }

    }
}
