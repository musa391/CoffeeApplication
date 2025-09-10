using CoffeeApplication.Context;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeApplication.Controllers
{
    public class AboutController : Controller
    {
        private readonly CoffeeDbContext _context;

        public AboutController(CoffeeDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "HAKKIMIZDA";
            var about = _context.Abouts.ToList();
            return View(about);  
        }

       
    }
}
