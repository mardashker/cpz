using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentTaskController : ControllerBase
    {
        private readonly DataContext _context;

        public StudentTaskController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentTask>>> GetStudentTasks()
        {
            return Ok(await _context.StudentTasks.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<StudentTask>>> CreateStudentTask(StudentTask student)
        {
            _context.StudentTasks.Add(student);
            await _context.SaveChangesAsync();

            return Ok(await _context.StudentTasks.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<StudentTask>>> UpdateStudentTask(StudentTask student)
        {
            var dbHero = await _context.StudentTasks.FindAsync(student.Id);
            if (dbHero == null)
                return BadRequest("StudentTask not found.");

            dbHero.StudentId = student.StudentId;
            dbHero.UniversityTaskId = student.UniversityTaskId;
            dbHero.Mark = student.Mark;

            await _context.SaveChangesAsync();

            return Ok(await _context.StudentTasks.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<StudentTask>>> DeleteStudentTask(int id)
        {
            var dbHero = await _context.StudentTasks.FindAsync(id);
            if (dbHero == null)
                return BadRequest("StudentTask not found.");

            _context.StudentTasks.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.StudentTasks.ToListAsync());
        }
    }
}
