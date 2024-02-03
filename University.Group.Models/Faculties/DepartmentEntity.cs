﻿namespace University.Group.Models.Faculties
{
    public class DepartmentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Head { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
        public DepartmentEntity()
        {

        }
        
        public DepartmentEntity(int id, string name, string head, string phone, string email)
        {
            Id = id;
            Name = name;
            Head = head;
            Phone = phone;
            Email = email;
        }
    }
}
