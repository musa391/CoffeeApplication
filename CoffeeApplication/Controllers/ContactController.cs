using CoffeeApplication.Models;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CoffeeApplication.Context;

namespace CoffeeApplication.Controllers
{
    public class ContactController : Controller
    {
        private readonly CoffeeDbContext _context;

        public ContactController(CoffeeDbContext context)
        {
            _context = context;
        }

        // GET: Contact
        public IActionResult Index()
        {
            ViewData["Title"] = "İLETİŞİM";
            return View();
        }

        // POST: Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Contact model)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(model);
                await _context.SaveChangesAsync();

                // Mail gönderme
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(model.Name, model.Email));
                message.To.Add(new MailboxAddress("musaa.sahn66@gmail.com", "musaa.sahn66@gmail.com"));
                message.Subject = "Yeni Contact Mesajı";
                message.Body = new TextPart("plain")
                {
                    Text = $"İsim: {model.Name}\n" +
                           $"E-posta: {model.Email}\n" +
                           $"Telefon: {model.Phone}"+
                            $"Mesaj: {model.Message}"
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("musaa.sahn66@gmail.com", "zffh eamd omim srgq"); // Gmail App Password
                    client.Send(message);
                    client.Disconnect(true);
                }

                TempData["Success"] = "Mesajınız gönderildi!";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}

