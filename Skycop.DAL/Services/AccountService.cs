using Skycop.DAL.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using Skycop.Model.Models;
using Skycop.Model.ViewModels;
using System.Data;
using System.Data.SqlClient;

namespace Skycop.DAL.Services
{
    public class AccountService: BaseService, IAccountService
    {
        #region Initialization
        private readonly QueryHolders.QH_AccountService queryHolder = null;
        private string connectionString;
        #endregion

        public AccountService()
        {
            this.queryHolder = new QueryHolders.QH_AccountService();
            connectionString = @"Server=DESKTOP-KNI7BEM\SQLEXPRESS;Database=Skycop;Trusted_Connection=true;";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
