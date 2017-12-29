using System.ComponentModel.DataAnnotations;

namespace musicstore.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}