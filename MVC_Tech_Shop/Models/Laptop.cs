using System.ComponentModel.DataAnnotations;

namespace MVC_Tech_Shop.Models
{
    public class Laptop
    {
        public int Id { get; set; }

        [Required, StringLength(100, MinimumLength = 3)]
        public string Model { get; set; }

        [Required, StringLength(100, MinimumLength = 3)]
        public string Processor { get; set; }

        [Required, StringLength(100, MinimumLength = 3)]
        public string Display { get; set; }

        [Range(0, 100_000_000)]
        public decimal Price { get; set; }
    }
}
