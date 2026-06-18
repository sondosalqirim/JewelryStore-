using Microsoft.AspNetCore.Mvc;
using Web_project_as.Data;
using Web_project_as.Models;

namespace Web_project_as.Controllers
{
    public class UserController : Controller
    {
        private JewelryContext context { get; set; }

        public UserController(JewelryContext ctx) => context = ctx;

        public IActionResult ShowAllUsers()
        {
            var users = context.Users.ToList();
            return View(users);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("SignIn");
            }
            return View(user);
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Email and password are required";
                return View();
            }
            var userByEmail = context.Users.FirstOrDefault(u => u.Email == email);
            if (userByEmail == null)
            {
                ViewBag.Error = "Email not found";
                return View();
            }
            if (userByEmail.Password != password)
            {
                ViewBag.Error = "Incorrect password";
                return View();
            }
            HttpContext.Session.SetInt32("UserID", userByEmail.UserID);
            HttpContext.Session.SetString("UserName", userByEmail.FullName);
            return RedirectToAction("Profile");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("ShowAllProudect", "Product");
        }

        public IActionResult Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("SignIn");
            }
            var user = context.Users.Find(userId.Value);
            if (user == null)
            {
                return RedirectToAction("SignIn");
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Profile(string oldPassword, string newPassword)
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("SignIn");
            }
            var user = context.Users.Find(userId.Value);
            if (user == null)
            {
                return RedirectToAction("SignIn");
            }
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
            {
                ViewBag.Error = "Both password fields are required";
                return View(user);
            }
            if (user.Password != oldPassword)
            {
                ViewBag.Error = "Old password is incorrect";
                return View(user);
            }
            user.Password = newPassword;
            context.SaveChanges();
            ViewBag.Message = "Password changed successfully";
            return View(user);
        }
    }
}
