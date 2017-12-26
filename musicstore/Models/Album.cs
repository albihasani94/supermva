using System;
using System.ComponentModel.DataAnnotations;

namespace musicstore.Models
{
    public class Album
    {
        public int ID { get; set; }
        public string Artist { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z'' - '\s]*$")]
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Range(0, 100.00)]
        public decimal Price { get; set; }
    }
}