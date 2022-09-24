using System.ComponentModel.DataAnnotations;

namespace MVC_Tech_Shop.Models
{
    public class Laptop
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Processor { get; set; }
        public string Display { get; set; }
        public decimal Price { get; set; }
    }
}
