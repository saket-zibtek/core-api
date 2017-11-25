using Skycop.Common.Constants;
using Skycop.Common.Exceptions;
using Skycop.DAL.Services;
using Skycop.Model.Models;
using System;
using System.Collections.Generic;

namespace Skycop.BAL.BusinessLogic
{
    public class UserBAL : BaseBAL
    {
        UserService _userService = UnitOfWork.UserService;

        public IEnumerable<Role> GetRoles()
        {
            try
            {
                var roles = _userService.GetRoles();
                return roles;
            }
            catch (Exception)
            {
                throw new DataNotFoundException(ErrorConstants.DATA_NOT_FOUND);
            }
        }

        public IEnumerable<User> GetUsers()
        {
            try
            {
                var users = _userService.GetUsers();
                return users;
            }
            catch (Exception)
            {
                throw new DataNotFoundException(ErrorConstants.DATA_NOT_FOUND);
            }
        }

        public IEnumerable<Device> GetDevices()
        {
            try
            {
                var devices = _userService.GetDevices();
                return devices;
            }
            catch (Exception)
            {
                throw new DataNotFoundException(ErrorConstants.DATA_NOT_FOUND);
            }
        }
    }
}
