using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GolovinskyAPI.Services;

namespace GolovinskyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/password")]
    public class PasswordController : ControllerBase
    {
        IRepository repo;
        public PasswordController(IRepository r)
        {
            repo = r;
        }
        // GET: api/password
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PasswordRecoveryInput model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var res = repo.RecoveryPassword(model);
            if (res.Length == 0)
            {
                return Ok(new 
                {
                    Message = "Пользователь не найден!",
                    Founded = false
                });
            }
            else
            {
                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync(model.EMail, "Востановление пароля Головинский", res);
                return Ok(new {
                    Message = $"Ваш пароль отправлен на email: { model.EMail }",
                    Founded = true
                });
            }
        }
    }
}
