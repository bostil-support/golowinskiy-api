using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolovinskyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/UserInfo")]
    public class UserInfoController : ControllerBase
    {
        // GET: api/UserInfo/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }
    }
}
