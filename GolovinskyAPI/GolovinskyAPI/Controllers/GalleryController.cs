using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolovinskyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Gallery")]
    public class GalleryController : ControllerBase
    {
        // POST: api/Gallery
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}
