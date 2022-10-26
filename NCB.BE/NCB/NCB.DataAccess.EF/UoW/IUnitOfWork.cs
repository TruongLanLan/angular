using Microsoft.EntityFrameworkCore.Storage;
using NCB.Data.Entities;
using NCB.DataAccess.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCB.DataAccess.EF.UoW
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Log_Login> LogLoginRepository { get; }
        Task<int> CommitAsync();
        int SaveChange();
    }
}
