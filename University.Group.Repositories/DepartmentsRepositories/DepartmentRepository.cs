using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using University.Group.Models.Faculties;

namespace University.Group.Repositories.DepartmentsRepositories
{
    public class DepartmentRepository : IRepository<DepartmentEntity>
    {
        private SqlConnection _connection;
        private readonly string _connectionString;

        public DepartmentRepository()
        {
        }

        public DepartmentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(DepartmentEntity entity)
        {
            string commandText = "INSERT INTO [Departments] (Name, Head, Phone, Email) VALUES(@name, @head, @phone, @email)";
            using (_connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, _connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@name", entity.Name);
                command.Parameters.AddWithValue("@head", entity.Head);
                command.Parameters.AddWithValue("@phone", entity.Phone);
                command.Parameters.AddWithValue("@email", entity.Email);
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

        public void Delete(DepartmentEntity entity)
        {
            string commandText = "DELETE FROM [Departments] WHERE Id = @id;";
            using (_connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, _connection);
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

        public DepartmentEntity Get(int id)
        {
            string commandText = "SELECT * FROM [Departments] WHERE Id = @id";
            DepartmentEntity department = new DepartmentEntity();
            using (_connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, _connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    command.Connection.Open();
                    SqlDataReader sReader = command.ExecuteReader();
                    while (sReader.Read())
                    {
                        department = new DepartmentEntity(Convert.ToInt32(sReader["Id"]), Convert.ToString(sReader["Name"]),
                            Convert.ToString(sReader["Head"]), Convert.ToString(sReader["Phone"]), Convert.ToString(sReader["Email"]));
                    }
                }
                catch { }
                finally
                {
                    command.Connection.Close();
                }
            }
            return department;
        }

        public List<DepartmentEntity> GetAll()
        {
            List<DepartmentEntity> departmentEntities = new List<DepartmentEntity>();
            string commandText = "SELECT * FROM [Departments]";
            using (_connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, _connection);
                command.CommandType = CommandType.Text;
                try
                {
                    command.Connection.Open();
                    SqlDataReader sReader = command.ExecuteReader();
                    while (sReader.Read())
                    {
                        departmentEntities.Add(new DepartmentEntity(Convert.ToInt32(sReader["Id"]), Convert.ToString(sReader["Name"]),
                            Convert.ToString(sReader["Head"]), Convert.ToString(sReader["Phone"]), Convert.ToString(sReader["Email"])));
                    }
                }
                catch { }
                finally
                {
                    command.Connection.Close();
                }
            }
            return departmentEntities;
        }

        public void Update(DepartmentEntity entity)
        {
            string commandText = "UPDATE [Departments] SET Name = @name, Head =  @head, Phone = @phone, Email = @email WHERE Id = @id";
            using (_connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, _connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@id", entity.Id);
                command.Parameters.AddWithValue("@name", entity.Name);
                command.Parameters.AddWithValue("@head", entity.Head);
                command.Parameters.AddWithValue("@phone", entity.Phone);
                command.Parameters.AddWithValue("@email", entity.Email);
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
