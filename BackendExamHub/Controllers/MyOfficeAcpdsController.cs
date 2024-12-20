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
    public class MyOfficeAcpdsController : ControllerBase
    {
        private readonly BackendExamHubContext _context;

        public MyOfficeAcpdsController(BackendExamHubContext context)
        {
            _context = context;
        }

        // GET: api/MyOfficeAcpds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyOfficeAcpd>>> GetMyOfficeAcpds()
        {
            return await _context.MyOfficeAcpds.ToListAsync();
        }

        // GET: api/MyOfficeAcpds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyOfficeAcpd>> GetMyOfficeAcpd(string id)
        {
            var myOfficeAcpd = await _context.MyOfficeAcpds.FindAsync(id);

            if (myOfficeAcpd == null)
            {
                return NotFound();
            }

            return myOfficeAcpd;
        }

        // PUT: api/MyOfficeAcpds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyOfficeAcpd(string id, MyOfficeAcpd myOfficeAcpd)
        {
            if (id != myOfficeAcpd.AcpdSid)
            {
                return BadRequest();
            }

            _context.Entry(myOfficeAcpd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyOfficeAcpdExists(id))
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

        // POST: api/MyOfficeAcpds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MyOfficeAcpd>> PostMyOfficeAcpd(MyOfficeAcpd myOfficeAcpd)
        {
            _context.MyOfficeAcpds.Add(myOfficeAcpd);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MyOfficeAcpdExists(myOfficeAcpd.AcpdSid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMyOfficeAcpd", new { id = myOfficeAcpd.AcpdSid }, myOfficeAcpd);
        }

        // DELETE: api/MyOfficeAcpds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyOfficeAcpd(string id)
        {
            var myOfficeAcpd = await _context.MyOfficeAcpds.FindAsync(id);
            if (myOfficeAcpd == null)
            {
                return NotFound();
            }

            _context.MyOfficeAcpds.Remove(myOfficeAcpd);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MyOfficeAcpdExists(string id)
        {
            return _context.MyOfficeAcpds.Any(e => e.AcpdSid == id);
        }
    }
}
