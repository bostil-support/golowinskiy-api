using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Models
{
    public class LoginSuccessModel
    {
        public int Result { get; set; }
        public bool IsItBoss { get; set; }
        public string Message { get; set; }
    }
}
