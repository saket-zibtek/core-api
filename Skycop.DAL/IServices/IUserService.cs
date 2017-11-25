using Skycop.Model.Models;
using System.Collections.Generic;

namespace Skycop.DAL.IServices
{
    public interface IUserService
    {
        IEnumerable<Role> GetRoles();
        IEnumerable<User> GetUsers();
        IEnumerable<Device> GetDevices();
    }
}
