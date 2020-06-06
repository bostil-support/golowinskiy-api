using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Infrastructure;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolovinskyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/SmsAero")]
    [DisableCors]
    public class SmsAeroController : Controller
    {
        private readonly ISms_aero _smsAero;
        public SmsAeroController(ISms_aero smsAero)
        {
            _smsAero = smsAero;
        }
        [HttpPost]
        public async Task<ActionResult> SendSms(string Phone, string Message)
        {
            var a = await _smsAero.Send(Phone, Message);
            return Ok();
        }
    }
}