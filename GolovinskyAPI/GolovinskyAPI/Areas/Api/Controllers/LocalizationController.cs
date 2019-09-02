using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolovinskyAPI.Areas.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Localization")]
    public class LocalizationController : ControllerBase
    {
        // POST: api/Localization
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}
