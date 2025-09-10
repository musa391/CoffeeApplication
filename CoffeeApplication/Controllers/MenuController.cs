using CoffeeApplication.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel;


namespace CoffeeApplication.Controllers
{
    public class MenuController : Controller
    {
        private readonly CoffeeDbContext _context;

        public MenuController(CoffeeDbContext context)
        {
            _context = context;
        }

        // Index action: kategori filtresi destekli
        public IActionResult Index(string category)
        {
            ViewData["Title"] = "MENÜ";

            var menus = from m in _context.menus
                        select m;

            if (!string.IsNullOrEmpty(category))
            {
                menus = menus.Where(m => m.Category.Contains(category));
            }

            return View(menus.ToList());
        }
    }
}

