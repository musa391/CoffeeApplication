using System.ComponentModel.DataAnnotations;

namespace CoffeeApplication.Models
{
    public class About
    {
        public int Id { get; set; }

        [Required]
        public string Baslık { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public string Yazar {  get; set; }

        [Required]
        public DateTime YayınTarihi { get; set; }

        [Required]
        public string ImageUrl { get; set; }    


    }
}
