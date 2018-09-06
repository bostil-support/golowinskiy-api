using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Services
{
    public class AuthServiceModel
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int LifeTime{ get; set; }
        public string Key { get; set; }
    }
}
