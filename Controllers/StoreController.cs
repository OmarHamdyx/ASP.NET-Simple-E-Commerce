
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
                double? total, sum = 0;
                foreach (var item in order.Products)
                {
                    total = item.Price * (double)item.Quantity;
                    sum += total;
                }

                if (sum == order.InvoicePrice)
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
                    return BadRequest($"Invoice cost should be equal total cost of all products (i.e {sum})");
                }


            }
            else
            {
                double? total, sum = 0;
                string errors;

                if (order.Products == null)
                    return BadRequest(errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage)));

                foreach (var item in order.Products)
                {
                    total = item.Price * (double)item.Quantity;
                    sum += total;
                }
                if (order.InvoicePrice==0)
                {
                    errors =string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage));

                }
                if (sum != order.InvoicePrice)
                {
                    errors = $"Invoice cost should be equal total cost of all products (i.e {sum})\n" + string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage));

                }
                else
                {
                    errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage));

                }
                return BadRequest(errors);
            }
        }

    }
}
