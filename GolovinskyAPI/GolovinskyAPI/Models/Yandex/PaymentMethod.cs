using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Models.Yandex
{
    public class PaymentMethod
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentMethodType type { get; set; }

        public Guid id { get; set; }
        public bool saved { get; set; }
        public string title { get; set; }
        public string phone { get; set; }
    }
}
