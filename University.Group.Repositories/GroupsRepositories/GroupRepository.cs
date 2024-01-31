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
        private SqlConnection connection;
        private readonly string connectionString;
        public GroupRepository()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Fork\InternshipWebApi\University.Group.Repositories\InternshipDB.mdf;Integrated Security=True";
        }
        public void Add(GroupEntity entity)
        {
            string commandText = "INSERT INTO [Groups] (Name, MajorSubject, Year, StudentCount, DepartmentId) VALUES(@name, @major, @year, @count, @departmentId)";
            using (connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@name", entity.Name);
                command.Parameters.AddWithValue("@major", entity.MajorSubject);
                command.Parameters.AddWithValue("@year", entity.Year);
                command.Parameters.AddWithValue("@count", entity.StudentCount);
                command.Parameters.AddWithValue("@departmentId", entity.DepartmentId);
                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch { }
                finally
                {
                    command.Connection.Close();
                }
            }
        }

        public void Delete(GroupEntity entity)
        {
            string commandText = "DELETE FROM [Groups] WHERE Id = @id;";
            using (connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@id", entity.Id);
                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch { }
                finally
                {
                    command.Connection.Close();
                }
            }

        }

        public GroupEntity Get(int id)
        {
            string commandText = "SELECT * FROM [Groups] WHERE Id = @id";
            GroupEntity group = new GroupEntity();
            using (connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    command.Connection.Open();
                    SqlDataReader sReader = command.ExecuteReader();
                    while (sReader.Read())
                    {
                        group = new GroupEntity(Convert.ToInt32(sReader["Id"]), Convert.ToString(sReader["Name"]),
                            Convert.ToString(sReader["MajorSubject"]), Convert.ToInt32(sReader["Year"]), Convert.ToInt32(sReader["StudentCount"]),
                            Convert.ToInt32(sReader["DepartmentId"]));
                    }
                }
                catch { }
                finally
                {
                    command.Connection.Close();
                }
            }
            return group;

        }

        public List<GroupEntity> GetAll()
        {
            List<GroupEntity> groupEntities = new List<GroupEntity>();
            string commandText = "SELECT * FROM [Groups]";
            using (connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.Text;
                try
                {
                    command.Connection.Open();
                    SqlDataReader sReader = command.ExecuteReader();
                    while (sReader.Read())
                    {
                        groupEntities.Add(new GroupEntity(Convert.ToInt32(sReader["Id"]), Convert.ToString(sReader["Name"]),
                            Convert.ToString(sReader["MajorSubject"]), Convert.ToInt32(sReader["Year"]), Convert.ToInt32(sReader["StudentCount"]),
                            Convert.ToInt32(sReader["DepartmentId"])));
                    }
                }
                catch { }
                finally
                {
                    command.Connection.Close();
                }
            }
            return groupEntities;
        }

        public void Update(GroupEntity entity)
        {
            string commandText = "UPDATE [Groups] Name = @name, MajorSubject = @major, Year = @year, StudentCount = @count, DepartmentId = @departmentId WHERE id = @id)";
            using (connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@id", entity.Id);
                command.Parameters.AddWithValue("@name", entity.Name);
                command.Parameters.AddWithValue("@major", entity.MajorSubject);
                command.Parameters.AddWithValue("@year", entity.Year);
                command.Parameters.AddWithValue("@count", entity.StudentCount);
                command.Parameters.AddWithValue("@departmentId", entity.DepartmentId);
                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch { }
                finally
                {
                    command.Connection.Close();
                }
            }

        }
    }
}
