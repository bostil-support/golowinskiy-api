using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Models
{
    public class LoginSuccessModel
    {
        public string AccessToken { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string UserId { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
    }
}
