using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GolovinskyAPI.Models;
using GolovinskyAPI.Models.Orders;
using GolovinskyAPI.Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace GolovinskyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        IRepository repo;
        public OrderController(IRepository r)
        {
            repo = r;
        }
        /*
         Для создания заказов при первом сбросе позиции в корзину (сделать это можно путем нажатия на значок корзины, который имеется на картинке на главной странице сайта, 
         либо во всплывающем окне на большой картинке) создается заголовок заказа.
         Для этого используется процедура
        [dbo].[sp_AddNewOrder]
        */
        // POST: api/Order
        [HttpPost]
        public IActionResult Post([FromBody]NewOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            NewOrderOutputModel res = repo.AddNewOrder(model);
            if(res.Ord_No == null)
            {
                return Ok(new { Message = "Не верный id пользователя", Status = false });
            }
            return Ok(res);
        }

        [HttpPost("/api/addtocart/")]
        public IActionResult AddToCart([FromBody] NewOrderItemInputModel model)
        {
            bool res;
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            res = repo.AddItemToCart(model);
            if (res) 
            {
                return Ok(new { Message = "Товар добавлен в корзину", Result = true });
            } else {
                return Ok(new { Message = "Не верные параметры. Товар не добавлне в корзину.", Result = false });
            }
        }

        [HttpPost("/api/order/changeqty/")]
        public IActionResult ChangeQty([FromBody] NewOrderItemInputModel model)
        {
            bool res;
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            res = repo.ChangeQty(model);
            if (!res)
            {
                return Ok(new { Result = false });
            }
            return Ok(new { Result = true });
        }

        
        /* В самом конце формирования заказа запускается процедура
          [dbo].[sp_OrderAsSMS], где пользователь в форме указывает адрес доставки 
        */
        [HttpPost("/api/order/save/")]
        public IActionResult SaveOrder([FromBody] NewOrderShippingInputModel model)
        {
            bool res;
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            res = repo.SaveOrder(model);
            
            return Ok(new { Result = res });
        }
    }
}
