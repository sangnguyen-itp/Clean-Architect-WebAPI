using Application.Interfaces.Common;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructures.Persistence.Context
{
    public class ApplicationDBContext : DbContext
    {
        //private readonly IDatetimeService _datetimeService;
        private readonly ICommonService _commonService;
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, ICommonService commonService): base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //_datetimeService = datetimeService;
            _commonService = commonService;
        }

        public DbSet<User> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _commonService.DatetimeService.NowUTC;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _commonService.DatetimeService.NowUTC;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
