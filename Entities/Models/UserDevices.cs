using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class UserDevices
    {
        [Key]
        public int UserDevicesId { get; set; }

        [ForeignKey("DeviceId")]
        [Required(ErrorMessage = "Device is required.")]
        public int DeviceId { get; set; } // FKey
        public Device? Device { get; set; }

        [ForeignKey("AppUserId")]
        [Required(ErrorMessage = "User is required.")]
        public int AppUserId { get; set; } //FKey
        public AppUser? AppUser { get; set; }

    }
}
