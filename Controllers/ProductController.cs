using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web_project_as.Data;
using Web_project_as.Models;

namespace Web_project_as.Controllers
{
    public class ProductController : Controller
    {
        private JewelryContext context { get; set; }

        public ProductController(JewelryContext ctx) => context = ctx;

        
        public IActionResult ShowAllProudect()
        {  var products = context.Products.ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {  var product = context.Products.Find(id);
              if (product == null)
            {  return NotFound();}
             
             return View(product);
        }
    }
}