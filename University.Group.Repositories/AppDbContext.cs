using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public DbSet<GroupEntity> Groups {get; set;}
        public DbSet<DepartmentEntity> Departments { get; set; }
    }
}
