using ASP.NET_Simple_E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
namespace ASP.NET_Simple_E_Commerce.Controllers
{
    public class StoreController : Controller
    {
        [Route("/")]
        public IActionResult HomePage()
        {
            return View();
        }

        [HttpPost("/order")]
        public IActionResult ReturnOrder(Order order)
        {
            try
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
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
