using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record DeviceDto
    {
        public int DeviceId { get; set; }
        public String? DeviceName { get; set; } = String.Empty;
        public String? ImageUrl { get; set; }
    }
}
