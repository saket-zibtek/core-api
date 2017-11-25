using System;
using System.Collections.Generic;
using System.Text;
using Skycop.DAL.Services;

namespace Skycop.DAL.UOW
{
    public class UnityOfWorks
    {
        #region Private Members

        private BaseService _BaseService;
        private UserService _UserService;
        private AccountService _AccountService;

        #endregion

        public BaseService BaseService
        {
            get { return _BaseService ?? (_BaseService = new BaseService()); }
        }

        public UserService UserService
        {
            get { return _UserService ?? (_UserService = new UserService()); }
        }

        public AccountService AccountService
        {
            get { return _AccountService ?? (_AccountService = new AccountService()); }
        }
    }
}
