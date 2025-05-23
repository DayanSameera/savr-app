using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Savr.Core.Domain.Models;

namespace Savr.Core.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<FinancialTransaction> Transactions { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<User> Users { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
