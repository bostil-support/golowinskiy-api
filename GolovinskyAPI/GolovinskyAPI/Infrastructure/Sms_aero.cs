using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GolovinskyAPI.Infrastructure
{
    /// <summary>
    /// класс для связи с смс-аеро
    /// </summary>
    public class Sms_aero : ISms_aero
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="configuration"></param>
        public Sms_aero(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// отправка сообщений
        /// </summary>
        /// <param name="Phone">номер телефона</param>
        /// <param name="Message">сообщение</param>

        public async Task<int> Send(string Phone, string Message)
        {
            try
            {
                var apikey = _configuration.GetValue<string>("SmsApiKey");
                var email = _configuration.GetValue<string>("SmsEmail");
                var rawHttpRequest = new Uri($"https://gate.smsaero.ru/v2/sms/send?number=" + Phone + $"&text=" + Message + $"&sign=SMS Aero&channel=INTERNATIONAL");
                var authorize = new Uri($"https://gate.smsaero.ru/v2/auth"); // {email}:{apikey}@
                var byteArray = Encoding.ASCII.GetBytes($"{email}:{apikey}");
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    var authMessage = await httpClient.GetAsync(authorize);
                    var httpResponseMessage = await httpClient.GetAsync(rawHttpRequest);
                    var content = await httpResponseMessage.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 0;
        }
    }
}
