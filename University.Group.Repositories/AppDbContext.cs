using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using University.Group.Models.Faculties;
using University.Group.Models.Groups;

namespace University.Group.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public void DetachAllEntities()
        {
            var undetachedEntriesCopy = this.ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Detached)
                .ToList();

            foreach (var entry in undetachedEntriesCopy)
                entry.State = EntityState.Detached;
        }
        public DbSet<GroupEntity> Groups {get; set;}
        public DbSet<DepartmentEntity> Departments { get; set; }
    }
}
