using Backend_Angular_Crud_Operation.Data;
using Backend_Angular_Crud_Operation.Model;
using Backend_Angular_Crud_Operation.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Angular_Crud_Operation.Repository
{
    public class StudentRepository:IStudentRepository
    {

        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool AddStudent(Student student)
        {
            _context.students.Add(student);
            return Save();
        }

        public bool DeleteStudent(Student student)
        {
            _context.students.Remove(student);
            return Save();
        }
        public bool Save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }

        public ICollection<Student> Getstudents()
        {
            return _context.students.ToList();
        }

        public bool updateStudent(Student student)
        {
            _context.students.Update(student);
            return Save();
        }

        public Student GetStudentById(int StudentId)
        {
            return _context.students.Find(StudentId);
        }
    }
}

