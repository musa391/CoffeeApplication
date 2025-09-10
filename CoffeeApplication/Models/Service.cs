using System.ComponentModel.DataAnnotations;

namespace CoffeeApplication.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }



    }
}
