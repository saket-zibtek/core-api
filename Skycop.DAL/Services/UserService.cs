using Dapper;
using Skycop.DAL.IServices;
using Skycop.Model.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Skycop.DAL.Services
{
    public class UserService : BaseService, IUserService
    {
        #region Initialization

        private readonly QueryHolders.QH_UserService queryHolder = null;
        private string connectionString;

        public UserService()
        {
            this.queryHolder = new QueryHolders.QH_UserService();
            connectionString = @"Server=DESKTOP-KNI7BEM\SQLEXPRESS;Database=Skycop;Trusted_Connection=true;";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        #endregion

        public IEnumerable<Role> GetRoles()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Role>(queryHolder.GET_ROLES);
            }
        }

        public IEnumerable<User> GetUsers()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>(queryHolder.GET_USERS);
            }
        }

        public IEnumerable<Device> GetDevices()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Device>(queryHolder.GET_DEVICES);
            }
        }
    }
}
