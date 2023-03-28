using Backend_Angular_Crud_Operation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Angular_Crud_Operation.Repository.IRepository
{
    public interface IStudentRepository
    {
        ICollection<Student> Getstudents();
        Student GetStudentById(int StudentId);
        bool AddStudent(Student student);
        bool updateStudent(Student student);
        bool DeleteStudent(Student student);
        bool Save();
    }
}