using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Models
{
    public class PasswordRecoveryInput
    {
        [Required]
        [EmailAddress]
        public string Phone { get; set; }
        [Required]
        public string Cust_ID_Main { get; set; }
    }
}
