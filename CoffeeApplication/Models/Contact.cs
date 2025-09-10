using System.ComponentModel.DataAnnotations;

namespace CoffeeApplication.Models
{
    public class Contact
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Lütfen isminizi girin")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen e-posta girin")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta girin")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen telefon numaranızı girin")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Lütfen mesajınızı yazın")]
        [StringLength(500, ErrorMessage = "Mesaj 500 karakteri geçemez")]
        public string Message { get; set; }

    }
}
