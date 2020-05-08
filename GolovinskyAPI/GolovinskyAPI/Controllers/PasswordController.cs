using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Infrastructure;
using GolovinskyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GolovinskyAPI.Services;
using Microsoft.AspNetCore.Cors;

namespace GolovinskyAPI.Controllers
{
    /// <summary>
    /// Изменение пароля
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    [Route("api/password")]
    [DisableCors]
    public class PasswordController : ControllerBase
    {
        IRepository repo;
        private readonly ISms_aero _sms_Aero;
        public PasswordController(IRepository r, ISms_aero sms_Aero)
        {
            repo = r;
            _sms_Aero = sms_Aero;
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
            if (String.IsNullOrEmpty(res[0]))
            {
                return Ok(new 
                {
                    Message = res[2],
                    Founded = false
                });
            }
            else
            if (res[0].Contains("@"))
            {
                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync(res[0], "Востановление пароля Головинский", res[1]);
                return Ok(new {
                    Message = res[2],
                    Founded = true
                });
            }
            else 
            {
                if (res[0].StartsWith("+")) res[0] = res[0].Remove(0, 1);
                await _sms_Aero.Send(res[0], res[1]);
                return Ok(new
                {
                    Message = res[2],
                    Founded = true
                });
            }
        }
    }
}