using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserDevicesManager : IUserDevicesService
    {
        private readonly IRepositoryManager _manager;

        public UserDevicesManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateOneDevice(UserDevices userDevices)
        {
            _manager.UserDevices.Create(userDevices);
            _manager.Save();
        }

        public void DeleteOneDevice(int id)
        {
            UserDevices userDevices = GetOneDevice(id, false);
            if (userDevices != null)
            {
                _manager.UserDevices.RemoveOneDevice(userDevices);
                _manager.Save();
            }
        }

        public IEnumerable<UserDevices> GetAllDevices(bool trackChanges)
        {
            return _manager.UserDevices.GetAllDevices(trackChanges);
        }

        public UserDevices? GetOneDevice(int id, bool trackChanges)
        {
            var userDevices = _manager.UserDevices.GetOneDevice(id, trackChanges);
            if (userDevices is null)
            {
                throw new Exception("Device Not Found!");
            }
            return userDevices;
        }

        public UserDevices GetOneDeviceForUpdate(int id, bool trackChanges)
        {
            var userDevices = GetOneDevice(id, trackChanges);
            return userDevices;
        }

        public void UpdateOneDevice(UserDevices userDevices)
        {
            _manager.UserDevices.UpdateOneDevice(userDevices);
            _manager.Save();
        }
    }
}
