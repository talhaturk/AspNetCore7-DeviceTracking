using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repositories.Config
{
    public class UserDevicesConfig : IEntityTypeConfiguration<UserDevices>
    {
        public void Configure(EntityTypeBuilder<UserDevices> builder)
        {
            //Statik kullanıcılar oluşmadan kullanılırsa hata verir!
            
            //builder.HasData(
            //    new UserDevices() { UserDevicesId = 1, AppUserId = 1, DeviceId = 1 },
            //    new UserDevices() { UserDevicesId = 2, AppUserId = 2, DeviceId = 2 },
            //    new UserDevices() { UserDevicesId = 3, AppUserId = 3, DeviceId = 3 }
            //);
        }
    }
}
