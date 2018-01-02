using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample_Sqlite.Models.Context
{
    public interface Iunitofwork : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
       
    }


}
