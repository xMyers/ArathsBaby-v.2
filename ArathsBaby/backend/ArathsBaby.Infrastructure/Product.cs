using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArathsBaby.Infrastructure
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string Photo { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public Decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int UnitInStock { get; set; }

        [Required]
        public string Color { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
