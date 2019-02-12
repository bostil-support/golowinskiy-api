using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using GolovinskyAPI.Models.Yandex;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Net;

namespace GolovinskyAPI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public void Pay(string sum)
        {
            // 1. Создайте платеж и получите ссылку для оплаты
            //decimal amount = decimal.Parse(sum.Text, CultureInfo.InvariantCulture.NumberFormat);
            decimal amount = decimal.Parse(sum, CultureInfo.InvariantCulture.NumberFormat);
            var idempotenceKey = Guid.NewGuid().ToString();
            var newPayment = new NewPayment
            {
                amount = new Amount { value = amount, currency = "RUB" },
                confirmation = new Confirmation { type = ConfirmationType.redirect, return_url = Url.Content("~/") }
            };
            Payment payment = _client.CreatePayment(newPayment, idempotenceKey);

            // 2. Перенаправьте пользователя на страницу оплаты
            string url = payment.confirmation.confirmation_url;
            Response.Redirect(url);
        }
    }
}