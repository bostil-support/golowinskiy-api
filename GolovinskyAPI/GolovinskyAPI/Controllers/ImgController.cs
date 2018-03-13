using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolovinskyAPI.Controllers
{
    //[Produces("application/json")]
    [Route("api/Img")]
    public class ImgController : ControllerBase
    {

        IRepository repo;
        public ImgController(IRepository r)
        {
            repo = r;
        }
        // GET: api/Img/5
        [HttpGet]
        ///
        public IActionResult Get(string AppCode, string ImgFileName)
        {
            var res = repo.GetImageMobile(AppCode, ImgFileName);
            if (res != null)
            {
                //return Ok("data:image/jpeg;base64," + Convert.ToBase64String(res));
                return File(res, "image/jpeg;base64");
            }
            else
            {
                return BadRequest();
            } 
            
        }


        // POST: api/Img
        [HttpPost]
        public IActionResult Post([FromBody] SearchPictureInfoInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                return Ok(repo.SearchPictureInfo(model));
            }
               
           
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
