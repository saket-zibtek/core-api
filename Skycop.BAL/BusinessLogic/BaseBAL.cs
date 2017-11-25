using System;
using Skycop.DAL.UOW;

namespace Skycop.BAL.BusinessLogic
{
    public class BaseBAL:IDisposable
    {
        protected static readonly UnityOfWorks UnitOfWork = new UnityOfWorks();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
