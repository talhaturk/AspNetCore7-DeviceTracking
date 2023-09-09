using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IDeviceRepository : IRepositoryBase<Device>
    {
        IQueryable<Device> GetAllDevices(bool trackChanges);
        Device? GetOneDevice(int id, bool trackChanges);
        void UpdateOneDevice(Device device);
        void RemoveOneDevice(Device device);
        void CreateOneDevice(Device device);
    }
}
