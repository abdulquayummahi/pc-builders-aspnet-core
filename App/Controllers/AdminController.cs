using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc; 

namespace App.Controllers
{
    public class AdminController(ProductService productService, OrderService orderService) : Controller
    {
        [HttpGet]
        public IActionResult Products()
        {
            return View(productService.Get());
        }

        [HttpPost]
        public IActionResult AddProduct(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                productService.Create(product);
            }

            return RedirectToAction("Products");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            return View(productService.Update(id));
        }


        [HttpPost]
        public IActionResult UpdateProduct(ProductDTO productDto)
        {
            if (ModelState.IsValid)
            {
                if (productService.Update(productDto))
                {
                    TempData["Msg"] = "Product Updated Successfully";
                    return RedirectToAction("Products");
                }
                TempData["Msg"] = "Failed to Update product";
            }

            return View(productDto);
        }

        public IActionResult DeleteProduct(int id)
        {
            if (ModelState.IsValid)
            {
                productService.Delete(id);
                TempData["Msg"] = "Product deleted successfully!";
            }

            return RedirectToAction("Products");
        }

        [HttpGet]
        public IActionResult Orders()
        {
            return View(orderService.Get());
        }

        [HttpPost]
        public IActionResult UpdateOrderStatus(int id, string status)
        {
            var order = orderService.Get(id);

            if (order != null)
            {
                order.Status = status;
                
                if(orderService.Update(order))
                {
                    TempData["Msg"] = "Order status update successful";
                }

                TempData["Msg"] = "Failed to update order status.";
            }

            return RedirectToAction("Orders");
        }
    }
}