using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Models.Yandex
{
    public enum PaymentStatus
    {
        pending,
        waiting_for_capture,
        succeeded,
        canceled
    }
}
