using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            return Ok(await _context.Students.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Student>>> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Student>>> UpdateStudent(Student student)
        {
            var dbHero = await _context.Students.FindAsync(student.Id);
            if (dbHero == null)
                return BadRequest("Student not found.");

            dbHero.Name = student.Name;
            dbHero.Group = student.Group;

            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id)
        {
            var dbHero = await _context.Students.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            _context.Students.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }
    }
}
