using Microsoft.EntityFrameworkCore;
using NCB.Data.Entities;
using NCB.DataAccess.EF.Implementations;
using NCB.DataAccess.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCB.DataAccess.EF.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly NCBDbContext _ncbDbContext;

        protected IGenericRepository<User> _userRepository;
        protected IGenericRepository<Log_Login> _logLoginRepository;

        public UnitOfWork(NCBDbContext ncbDbContext)
        {
            _ncbDbContext = ncbDbContext;
        }
        public IGenericRepository<User> UserRepository
        {
            get
            {
                if(this._userRepository == null)
                {
                    this._userRepository = new GenericRepository<User>(_ncbDbContext);
                }
                return _userRepository;
            }
        }
        public IGenericRepository<Log_Login> LogLoginRepository
        {
            get
            {
                if(this._logLoginRepository == null)
                {
                    this._logLoginRepository = new GenericRepository<Log_Login>(_ncbDbContext);
                }
                return _logLoginRepository;
            }
        }
        public int SaveChange()
        {
            return _ncbDbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _ncbDbContext.SaveChangesAsync(new CancellationToken());

        }

        private bool dispose = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.dispose)
            {
                if (disposing)
                {
                    _ncbDbContext.Dispose();
                }
            }
            this.dispose = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
