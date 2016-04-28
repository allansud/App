using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.Interface
{
    public interface IDbContextFactory
    {
        TContext Create<TContext>(string nameOrConnectionString) where TContext : DbContext;
        void Release<TContext>() where TContext : DbContext;
    }
}
