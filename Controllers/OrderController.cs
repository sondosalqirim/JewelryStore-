using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Web_project_as.Data;
using Web_project_as.Models;

namespace Web_project_as.Controllers
{
    public class OrderController : Controller
    {
        private JewelryContext context { get; set; }

        public OrderController(JewelryContext ctx) => context = ctx;
 
        public IActionResult ShowAllOrders()
        {
            var orders = context.Orders
                                .Include(o => o.User)
                                .Include(o => o.Product)
                                .ToList();
            return View(orders);
        }
    }
}