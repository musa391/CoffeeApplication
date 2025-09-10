using CoffeeApplication.Context;

using CoffeeApplication.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace CoffeeApplication.Controllers
{
    public class AppController : Controller
    {
        private readonly CoffeeDbContext _context;

        public AppController(CoffeeDbContext context)
        {
            _context = context;
        }

        // Listeleme
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "KENDİN TASARLA";
            var apps = await _context.Apps.ToListAsync();
            return View(apps);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(App model)
        {
            if (ModelState.IsValid)
            {
                // DB'ye kaydet
                model.CreatedDate = DateTime.Now;
                _context.Apps.Add(model);
                await _context.SaveChangesAsync();

                // Mail gönder
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Coffee App", "musaa.sahn66@gmail.com"));
                message.To.Add(new MailboxAddress("Kendi Mailin", "musaa.sahn66@gmail.com"));
                message.Subject = "Yeni Kahve Tarifi Oluşturuldu";
                message.Body = new TextPart("plain")
                {
                    Text = $"Kahve Adı: {model.Name}\n" +
                           $"Açıklama: {model.Description}\n" +
                           $"Malzemeler: {model.material}\n" +
                           $"Oluşturulma Tarihi: {model.CreatedDate}"
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("musaa.sahn66@gmail.com", "zffh eamd omim srgq");
                    client.Send(message);
                    client.Disconnect(true);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int id)
        {
            var app = await _context.Apps.FindAsync(id);
            if (app == null)
                return NotFound();

            return View(app);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, App model)
        {
            if (id != model.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Apps.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var app = await _context.Apps.FindAsync(id);
            if (app != null)
            {
                _context.Apps.Remove(app);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}