using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserDevicesRepository : RepositoryBase<UserDevices>, IUserDevicesRepository
    {
        public UserDevicesRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneDevice(UserDevices userDevices) => Create(userDevices);

        public void RemoveOneDevice(UserDevices userDevices) => Remove(userDevices);

        public void UpdateOneDevice(UserDevices userDevices) => Update(userDevices);

        public IQueryable<UserDevices> GetAllDevices(bool trackChanges) => GetAll(trackChanges).Include(d => d.Device).Include(d => d.AppUser);
        // Include metodunu kullanmayınca UserDevices nesnesindeki Device ve AppUser alanları null olarak geliyor!

        public UserDevices? GetOneDevice(int id, bool trackChanges)
        {
            return FindByCondition(d => d.UserDevicesId.Equals(id), trackChanges);
        }

    }
}
