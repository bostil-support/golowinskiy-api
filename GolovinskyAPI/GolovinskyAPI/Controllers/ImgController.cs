using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolovinskyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Img")]
    public class ImgController : ControllerBase
    {
        // GET: api/Img/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Img
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Img/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
