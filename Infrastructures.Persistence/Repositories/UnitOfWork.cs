using Application.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructures.Persistence.Context;
using System;
using System.Threading.Tasks;

namespace Infrastructures.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public IUserRepositoryAsync Users { get; }


        public UnitOfWork(
                ApplicationDBContext context,
                IUserRepositoryAsync userRepositoryAsync
            )
        {
            _context = context;
            Users = userRepositoryAsync;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
