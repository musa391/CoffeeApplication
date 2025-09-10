using System.ComponentModel.DataAnnotations;

namespace CoffeeApplication.Models
{
    public class Menu
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
