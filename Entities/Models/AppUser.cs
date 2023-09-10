using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AppUser : IdentityUser<int>
    {
        public String? Name { get; set; } = String.Empty;
        public String Surname { get; set; } = String.Empty;
        public String? ImageUrl { get; set; }

        public List<UserDevices> UserDevices { get; set; }
    }
}
