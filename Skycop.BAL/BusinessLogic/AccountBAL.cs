using Skycop.DAL.Services;

namespace Skycop.BAL.BusinessLogic
{
    public class AccountBAL : BaseBAL
    {
        AccountService _accountService = UnitOfWork.AccountService;
    }
}
