using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using University.Group.Models.Faculties;


namespace University.Group.Repositories.DepartmentsRepositories
{
    public class DepartmentRepository : IRepository<DepartmentEntity>
    {
        private SqlConnection connection;
        private string connectionString;

        public DepartmentRepository()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Fork\InternshipWebApi\University.Group.Repositories\InternshipDB.mdf;Integrated Security=True";
        }

        public void Add(DepartmentEntity entity)
        {
            string commandText = "INSERT INTO Department (Name, Head, Phone, Email) VALUES(@name, @head, @phone, @email)";
            using (connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
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
                catch {}
                finally
                {
                    command.Connection.Close();
                }
            }
        }

        public void Delete(DepartmentEntity entity)
        {
            throw new NotImplementedException();
        }

        public DepartmentEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<DepartmentEntity> GetAll()
        {
            List<DepartmentEntity> departmentEntities = new List<DepartmentEntity>();
            string commandText = "SELECT * FROM Department";
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
            throw new NotImplementedException();
        }
    }
}
