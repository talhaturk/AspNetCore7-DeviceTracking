using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record RegisterDto
    {
        public String? Name { get; set; }
        public String? Surname { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        public String? UserName { get; init; }
        [Required(ErrorMessage = "Email is required.")]
        public String? Email { get; init; }
        [Required(ErrorMessage = "Password is required.")]
        public String? Password { get; init; }
        [Required(ErrorMessage = "Role is required.")]
        public String? Role { get; set; }
        public String? ImageUrl { get; set; }
    }
}
