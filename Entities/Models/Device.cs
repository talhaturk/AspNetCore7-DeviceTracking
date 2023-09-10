using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        public String? DeviceName { get; set; } = String.Empty;
        public List<UserDevices> UserDevices { get; set; }
        public String? ImageUrl { get; set; }
    }
}
