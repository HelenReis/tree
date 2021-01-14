using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TreeStride.Data.Repositories.Transaction.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Commit();

        Task Rollback();
    }
}
