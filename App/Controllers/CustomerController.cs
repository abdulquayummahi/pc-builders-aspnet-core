using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace App.Controllers
{
    public class CustomerController(ProductService productService, OrderService orderService) : Controller
    {
        [HttpGet]
        public IActionResult Products()
        {
            return View(productService.Get());
        }

        [HttpPost]
        public IActionResult BuyNow(OrderDTO orderDto)
        {
            if (ModelState.IsValid)
            {
                orderDto.UserId = HttpContext.Session.GetInt32("Id")!.Value;

                if (orderService.Create(orderDto))
                {
                    TempData["Msg"] = "Order placed successfully!";
                    return RedirectToAction("Products");
                }
                TempData["Msg"] = "Sorry, there was an issue placing your order.";

            }
            return RedirectToAction("Products");
        }

        public IActionResult MyOrders()
        {
            var myOrders = orderService.Get().Where(o => o.UserId == HttpContext.Session.GetInt32("Id")).ToList();

            return View(myOrders);
        }
    }
}