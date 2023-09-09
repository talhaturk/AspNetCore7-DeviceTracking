using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record UserForAutheticationDto
    {
        [Required(ErrorMessage = "Username is required.")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; init; }
        private string? _returnUrl;

        public string ReturnUrl
        {
            get
            {
                if (_returnUrl is null)
                    return "/";
                else
                    return _returnUrl;
            }

            set
            {
                _returnUrl = value;
            }
        }
    }
}
