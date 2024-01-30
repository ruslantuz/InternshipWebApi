using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using University.Group.Models.Groups;
using Microsoft.EntityFrameworkCore;
using University.Group.Models.Faculties;

namespace University.Group.Repositories.GroupsRepositories
{
    public class GroupRepository : IRepository<GroupEntity>
    {
        private readonly AppDbContext context;
        public GroupRepository()
        {
        }
        public GroupRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(GroupEntity entity)
        {
            context.DetachAllEntities();
            context.Groups.Add(entity);
            context.SaveChanges();
        }

        public void Delete(GroupEntity entity)
        {
            context.Groups.Remove(entity);
            context.SaveChanges();
        }

        public GroupEntity Get(int id)
        {
            return context.Groups.Find(id);
        }

        public List<GroupEntity> GetAll()
        {
            return context.Groups.ToList();
        }

        public void Update(GroupEntity entity)
        {
            var group = context.Groups.Attach(entity);
            group.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
