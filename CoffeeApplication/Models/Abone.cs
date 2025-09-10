using System.ComponentModel.DataAnnotations;

namespace CoffeeApplication.Models
{
    public class Abone
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        [Display(Name = "E-posta Adresi")]
        public string Eposta { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        public DateTime KayitTarihi { get; set; } = DateTime.Now;
    }
}
