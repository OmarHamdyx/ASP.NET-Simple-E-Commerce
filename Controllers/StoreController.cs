
using ASP.NET_Simple_E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;


namespace ASP.NET_Simple_E_Commerce.Controllers
{


    public class StoreController : Controller
    {
        [HttpPost("/order")]

        public IActionResult ReturnOrder(Order order)
        {

            if (ModelState.IsValid)
            {
                Random random = new();
                var randomNumber = random.Next(1, 100000);
                order.OrderNo = randomNumber;
                HttpContext.Response.StatusCode = 200;

                return Json(new
                {
                    orderNumber = randomNumber
                });
            }
            else
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage));
                return BadRequest(errors);

            }
        }

    }
}
