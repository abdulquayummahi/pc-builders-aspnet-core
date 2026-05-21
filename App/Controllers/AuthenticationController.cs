using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace App.Controllers
{
    public class AuthenticationController(UserService userService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserDTO userDto)
        {
            var currentUser = userService.Login(userDto.Email, userDto.Password);

            if (currentUser != null)
            {
                HttpContext.Session.SetInt32("Id", currentUser.Id);
                HttpContext.Session.SetString("Role", currentUser.Role);
                HttpContext.Session.SetString("Name", currentUser.Name);

                if (currentUser.Role == "Admin")
                {
                    return RedirectToAction("Products", "Admin");
                }
                return RedirectToAction("Products", "Customer");
            }

            ViewBag.Error = "Invalid email or password.";
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(UserDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }

            if (userService.CheckExistingEmail(userDto.Email) != null)
            {
                ViewBag.Error = "Email already exists";
                return View(userDto);
            }

            if (userService.Register(userDto))
            {
                return RedirectToAction("Login", "Authentication");
            }

            ViewBag.Error = "Registration failed. Please try again.";
            return View(userDto);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Authentication");
        }
    }
}
