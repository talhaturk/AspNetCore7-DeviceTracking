using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
    public class DeviceConfig : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasData(
                new Device() { DeviceId = 1, DeviceName = "Computer", ImageUrl = "/images/device/computer.jpg" },
                new Device() { DeviceId = 2, DeviceName = "Monitor", ImageUrl = "/images/device/monitor.jpg" },
                new Device() { DeviceId = 3, DeviceName = "Mouse", ImageUrl = "/images/device/mouse.jpg" });
        }
    }
}
