using System.ComponentModel.DataAnnotations;

namespace CoffeeApplication.Models
{
    public class App
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string  material { get; set; }

        [Required]
        public DateTime? CreatedDate { get; set; } = DateTime.MinValue;


    }
}
