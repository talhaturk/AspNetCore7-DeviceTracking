using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserDevicesService
    {
        IEnumerable<UserDevices> GetAllDevices(bool trackChanges);
        UserDevices? GetOneDevice(int id, bool trackChanges);
        void CreateOneDevice(UserDevices userDevices);
        void UpdateOneDevice(UserDevices userDevices);
        void DeleteOneDevice(int id);
        UserDevices GetOneDeviceForUpdate(int id, bool trackChanges);

    }
}
