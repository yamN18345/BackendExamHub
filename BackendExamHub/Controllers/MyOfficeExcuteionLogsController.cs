using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendExamHub.Models;

namespace BackendExamHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyOfficeExcuteionLogsController : ControllerBase
    {
        private readonly BackendExamHubContext _context;

        public MyOfficeExcuteionLogsController(BackendExamHubContext context)
        {
            _context = context;
        }

        // GET: api/MyOfficeExcuteionLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyOfficeExcuteionLog>>> GetMyOfficeExcuteionLogs()
        {
            return await _context.MyOfficeExcuteionLogs.ToListAsync();
        }

        // GET: api/MyOfficeExcuteionLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyOfficeExcuteionLog>> GetMyOfficeExcuteionLog(long id)
        {
            var myOfficeExcuteionLog = await _context.MyOfficeExcuteionLogs.FindAsync(id);

            if (myOfficeExcuteionLog == null)
            {
                return NotFound();
            }

            return myOfficeExcuteionLog;
        }

        // PUT: api/MyOfficeExcuteionLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyOfficeExcuteionLog(long id, MyOfficeExcuteionLog myOfficeExcuteionLog)
        {
            if (id != myOfficeExcuteionLog.DeLogAutoId)
            {
                return BadRequest();
            }

            _context.Entry(myOfficeExcuteionLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyOfficeExcuteionLogExists(id))
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

        // POST: api/MyOfficeExcuteionLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MyOfficeExcuteionLog>> PostMyOfficeExcuteionLog(MyOfficeExcuteionLog myOfficeExcuteionLog)
        {
            _context.MyOfficeExcuteionLogs.Add(myOfficeExcuteionLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyOfficeExcuteionLog", new { id = myOfficeExcuteionLog.DeLogAutoId }, myOfficeExcuteionLog);
        }

        // DELETE: api/MyOfficeExcuteionLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyOfficeExcuteionLog(long id)
        {
            var myOfficeExcuteionLog = await _context.MyOfficeExcuteionLogs.FindAsync(id);
            if (myOfficeExcuteionLog == null)
            {
                return NotFound();
            }

            _context.MyOfficeExcuteionLogs.Remove(myOfficeExcuteionLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MyOfficeExcuteionLogExists(long id)
        {
            return _context.MyOfficeExcuteionLogs.Any(e => e.DeLogAutoId == id);
        }
    }
}
