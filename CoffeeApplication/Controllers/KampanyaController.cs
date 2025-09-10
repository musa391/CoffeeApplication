
using CoffeeApplication.Context;
using CoffeeApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Threading.Tasks;


namespace CoffeeApplication.Controllers
{
    public class KampanyaController : Controller
    {
        private readonly CoffeeDbContext _context;

        public KampanyaController(CoffeeDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> KayitOl(string eposta)
        {
            if (string.IsNullOrWhiteSpace(eposta))
            {
                TempData["Hata"] = "Lütfen geçerli bir e-posta giriniz.";
                return RedirectToAction("Index", "Home");
            }

            var abonelik = new Abone { Eposta = eposta };
            _context.Abones.Add(abonelik);
            await _context.SaveChangesAsync();

            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress("musaa.sahn66@gmail.com"); // Gönderen
                mail.To.Add("musaa.sahn66@gmail.com"); // Senin mailin
                mail.Subject = "Yeni Kampanya Kaydı";
                mail.Body = $"Yeni abonelik: {eposta}";

                using (var smtp = new SmtpClient("smtp.gmail.com")) // SMTP sunucunu yaz
                {
                    smtp.Port = 587; // veya servis sağlayıcına göre 465
                    smtp.Credentials = new System.Net.NetworkCredential("musaa.sahn66@gmail.com", "ckbf tncb dppd aejg");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }

                TempData["Basarili"] = "Kampanya kaydınız başarıyla yapıldı ve bize iletildi!";
            }
            catch
            {
                TempData["Hata"] = "Kampanya kaydınız kaydedildi ama mail gönderilemedi.";
            }

            TempData["Basarili"] = "Kampanya bildirimlerine başarıyla kayıt oldunuz!";
            return RedirectToAction("Index", "Home");
        }
    }
}

