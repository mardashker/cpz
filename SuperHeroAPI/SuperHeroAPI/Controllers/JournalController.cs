using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly DataContext _context;

        public JournalController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Journal>>> GetJournals()
        {
            return Ok(await _context.Journals.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Journal>>> CreateJournal(Journal task)
        {
            _context.Journals.Add(task);
            await _context.SaveChangesAsync();

            return Ok(await _context.Journals.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Journal>>> UpdateJournal(Journal task)
        {
            var dbHero = await _context.Journals.FindAsync(task.Id);
            if (dbHero == null)
                return BadRequest("Journal not found.");

            dbHero.StudentId = task.StudentId;
            dbHero.ExamMark = task.ExamMark;
            dbHero.VisitPercentage = task.VisitPercentage;

            await _context.SaveChangesAsync();

            return Ok(await _context.Journals.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Journal>>> DeleteJournal(int id)
        {
            var dbHero = await _context.Journals.FindAsync(id);
            if (dbHero == null)
                return BadRequest("TaJournalsk not found.");

            _context.Journals.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Journals.ToListAsync());
        }
    }
}
