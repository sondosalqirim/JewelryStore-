using Microsoft.AspNetCore.Mvc;
using Web_project_as.Data;
using Web_project_as.Models;

namespace Web_project_as.Controllers
{
    public class ProductController : Controller
    {
        private JewelryContext context { get; set; }

        public ProductController(JewelryContext ctx) => context = ctx;

        public IActionResult ShowAllProudect()
        {
            var products = context.Products.ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult SearchProduct(string searchString)
        {
            var products = context.Products.ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.ProductName.ToLower().Contains(searchString.ToLower())).ToList();
            }
            return View(products);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            var relatedOrders = context.Orders.Where(o => o.ProductID == id).ToList();
            if (relatedOrders.Any())
            {
                context.Orders.RemoveRange(relatedOrders);
            }
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("ShowAllProudect");
        }
    }
}
