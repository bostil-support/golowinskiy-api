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
    /// <summary>
    /// Изменение пароля
    /// </summary>
    /// <returns></returns>
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
        /// <summary>
        /// Восстановление пароля и отправка его на email
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PasswordRecoveryInput model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}
            
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
                await emailService.SendEmailAsync(res[0], "Востановление пароля Головинский", res[1]);
                return Ok(new {
                    Message = $"Ваш пароль отправлен на email: { res[0] }",
                    Founded = true
                });
            }
        }
    }
}