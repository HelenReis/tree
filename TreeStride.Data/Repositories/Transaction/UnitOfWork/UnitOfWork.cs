using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreeStride.Data.Data;

namespace TreeStride.Data.Repositories.Transaction.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public Task Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
