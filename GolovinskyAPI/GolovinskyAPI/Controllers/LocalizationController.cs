using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolovinskyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Localization")]
    [DisableCors]
    public class LocalizationController : ControllerBase
    {
        // POST: api/Localization
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}
