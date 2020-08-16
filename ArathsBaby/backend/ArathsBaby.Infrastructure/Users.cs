using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArathsBaby.Infrastructure
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es requerido ")]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "La contraseña debe tener como minimo 8 caracteres")]
        public string Password { get; set; }

        public string Role { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Colony { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int OutsideNumber { get; set; }

        [Required]
        public int InternalNumber { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }


    }
}
