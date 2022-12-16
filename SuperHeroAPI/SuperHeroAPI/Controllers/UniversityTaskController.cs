using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityTaskController : ControllerBase
    {
        private readonly DataContext _context;

        public UniversityTaskController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<UniversityTask>>> GetTasks()
        {
            return Ok(await _context.UniversityTasks.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<UniversityTask>>> CreateTask(UniversityTask task)
        {
            _context.UniversityTasks.Add(task);
            await _context.SaveChangesAsync();

            return Ok(await _context.UniversityTasks.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<UniversityTask>>> UpdateTask(UniversityTask task)
        {
            var dbHero = await _context.UniversityTasks.FindAsync(task.Id);
            if (dbHero == null)
                return BadRequest("Task not found.");

            dbHero.Name = task.Name;
            dbHero.Time = task.Time;
            dbHero.Priority = task.Priority;
            dbHero.Status = task.Status;

            await _context.SaveChangesAsync();

            return Ok(await _context.UniversityTasks.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UniversityTask>>> DeleteTask(int id)
        {
            var dbHero = await _context.UniversityTasks.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Task not found.");

            _context.UniversityTasks.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.UniversityTasks.ToListAsync());
        }
    }
}
