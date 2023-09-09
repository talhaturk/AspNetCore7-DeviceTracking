using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IDeviceService
    {
        IEnumerable<Device> GetAllDevices(bool trackChanges);
        Device? GetOneDevice(int id, bool trackChanges);
        void CreateOneDevice(DeviceDtoForInsertion deviceDto);
        void UpdateOneDevice(DeviceDtoForUpdate deviceDto);
        void DeleteOneDevice(int id);
        DeviceDtoForUpdate GetOneDeviceForUpdate(int id, bool trackChanges);
    }
}
