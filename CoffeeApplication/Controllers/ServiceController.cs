using CoffeeApplication.Context;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeApplication.Controllers
{
    public class ServiceController : Controller
    {
        private readonly CoffeeDbContext _context;  

        public ServiceController(CoffeeDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "HİZMETLERİMİZ";
            var service = _context.services.ToList();
            return View(service);
        }
    }
}
