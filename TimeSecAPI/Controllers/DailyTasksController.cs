using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;

namespace TimeSecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyTasksController : ControllerBase
    {
        private readonly DailyTaskContext _context;

        public DailyTasksController(DailyTaskContext context)
        {
            _context = context;
        }

        // GET: api/DailyTask
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyTask>>> GetDailyTask()
        {
            return await _context.DailyTask.ToListAsync();
        }

        // GET: api/DailyTask/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyTask>> GetDailyTask(int id)
        {
            var dailyTask = await _context.DailyTask.FindAsync(id);

            if (dailyTask == null)
            {
                return NotFound();
            }

            return dailyTask;
        }

        // PUT: api/DailyTask/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyTask(int id, DailyTask dailyTask)
        {
            if (id != dailyTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(dailyTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DailyTask
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DailyTask>> PostDailyTask(DailyTask dailyTask)
        {
            _context.DailyTask.Add(dailyTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDailyTask", new { id = dailyTask.Id }, dailyTask);
        }

        // DELETE: api/DailyTask/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDailyTask(int id)
        {
            var dailyTask = await _context.DailyTask.FindAsync(id);
            if (dailyTask == null)
            {
                return NotFound();
            }

            _context.DailyTask.Remove(dailyTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DailyTaskExists(int id)
        {
            return _context.DailyTask.Any(e => e.Id == id);
        }
    }
}
