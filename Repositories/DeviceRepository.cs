using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DeviceRepository : RepositoryBase<Device>, IDeviceRepository
    {
        public DeviceRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneDevice(Device device) => Create(device);

        public void RemoveOneDevice(Device device) => Remove(device);

        public void UpdateOneDevice(Device device) => Update(device);

        public IQueryable<Device> GetAllDevices(bool trackChanges) => GetAll(trackChanges);
        
        public  Device? GetOneDevice(int id, bool trackChanges)
        {
            return FindByCondition(d => d.DeviceId.Equals(id), trackChanges);
        }


    }
}
