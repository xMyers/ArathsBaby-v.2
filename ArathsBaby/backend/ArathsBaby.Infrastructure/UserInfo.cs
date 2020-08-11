using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArathsBaby.Infrastructure
{
    public class UserInfo
    {
        public int iid { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "La contraseña debe tener como minimo 8 caracteres")]
        public string Password { get; set; }
    }
}
