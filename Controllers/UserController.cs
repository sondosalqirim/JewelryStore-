using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
    }
}