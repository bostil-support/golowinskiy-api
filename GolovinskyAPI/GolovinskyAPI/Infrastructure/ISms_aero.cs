using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Infrastructure
{
    /// <summary>
    /// публичный интерфейс для доступа к смс сервису
    /// </summary>
   public interface ISms_aero
    {
        /// <summary>
        /// отправка сообщений
        /// </summary>
        /// <param name="Phone">номер телефона</param>
        /// <param name="Message">сообщение</param>
        Task<int> Send(string Phone, string Message);
    }
}
