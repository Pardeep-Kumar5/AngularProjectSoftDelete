using Backend_Angular_Crud_Operation.Data;
using Backend_Angular_Crud_Operation.Model;
using Backend_Angular_Crud_Operation.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Angular_Crud_Operation.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _context.students.Where(s => !s.IsDelete);
        }
        [HttpGet("{id:int}")]
        public Student Get(int id)
        {
            return _context.students.FirstOrDefault(s => s.Id == id && !s.IsDelete);
        }
       
        [HttpPost]
        public IActionResult SaveStudent([FromBody]Student Student)
        { 
            _context.students.Add(Student);
            _context.SaveChanges();
            return Ok(Student);
        }
        [HttpPut]
        public IActionResult UpdateStudent(int id,[FromBody] Student student)
        {
            if (student != null)
            {
                _context.students.Update(student);
                _context.SaveChanges();
            }
            return Ok(student);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            var Studentindb = _context.students.FirstOrDefault(s => s.Id == id && !s.IsDelete);
            if (Studentindb != null)
                _context.Remove(Studentindb);
            _context.SaveChanges();
        }
    }
}
