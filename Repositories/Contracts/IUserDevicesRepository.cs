using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IUserDevicesRepository : IRepositoryBase<UserDevices>
    {
        IQueryable<UserDevices> GetAllDevices(bool trackChanges);
        UserDevices? GetOneDevice(int id, bool trackChanges);
        void UpdateOneDevice(UserDevices userDevices);
        void RemoveOneDevice(UserDevices userDevices);
        void CreateOneDevice(UserDevices userDevices);
    }
}
