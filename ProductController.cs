using CRUDApp.Data;
using CRUDApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace CRUDApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            IEnumerable<Product> products = _context.products.ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name , Price, Description, Stock")] Product modal)
        {
            if (ModelState.IsValid)
            {
                _context.products.Add(modal);
                _context.SaveChanges();
                TempData["Notification"] = "Product Create Successfully";
                TempData["NotificationType"] = "success";
                return RedirectToAction("Index");
            }
            return View(modal);
        }
        [HttpGet]

        public IActionResult Edit(int id)
        {
            var product = _context.products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return View(product);
            }
        }
        [HttpPost]
        public IActionResult Edit([Bind("Id, Name , Price, Description, Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.products.Update(product);
                _context.SaveChanges();
                TempData["Notification"] = "Product Updated Successfully";
                TempData["NotificationType"] = "success";
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _context.products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return View(product);
            }
        }
        public IActionResult DeleteConfirm(int id)
        {
            var product = _context.products.Find(id);
            if (product != null)
            {
                _context.products.Remove(product);
                _context.SaveChanges();
                TempData["Notification"] = "Product Deleted Successfully";
                TempData["NotificationType"] = "success";
            }
            return RedirectToAction("Index");
        }


    }
}
