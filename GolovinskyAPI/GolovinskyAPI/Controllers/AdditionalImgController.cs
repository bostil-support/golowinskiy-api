using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Models.ViewModels.Images;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolovinskyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/AdditionalImg")]
    public class AdditionalImgController : ControllerBase
    {
        IRepository repo;
        public AdditionalImgController(IRepository r)
        {
            repo = r;
        }

        // POST: api/AdditionalImg
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] NewAdditionalPictureInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest( new { result = false, message = "Не корректный запрос"});
            }
            return Ok(repo.InsertAdditionalPictureToProduct(model));
        }
        
        // PUT: api/AdditionalImg/
        [HttpPut("api/AdditionalImg/")]
        public IActionResult Put([FromBody] NewAdditionalPictureInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { result = false, message = "Не корректный запрос" });
            }
            return Ok(repo.UpdateAdditionalPictureToProduct(model));
        }

        // DELETE: api/AdditionalImg/
        [HttpDelete("api/AdditionalImg/")]
        public IActionResult Delete([FromBody] NewAdditionalPictureInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { result = false, message = "Не корректный запрос" });
            }
            return Ok(repo.DeleteAdditionalPictureToProduct(model));
        }
    }
}
