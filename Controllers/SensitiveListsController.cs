using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Flash.Test.Data;
using Flash.Test.Models;
using System.Security.Policy;

namespace Flash_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensitiveListsController : ControllerBase
    {
        private readonly FlashContext _context;

        public SensitiveListsController(FlashContext context)
        {
            _context = context;
        }

        // GET: api/SensitiveLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensitiveList>>> GetSensitiveLists()
        {
          if (_context.SensitiveLists == null)
          {
              return NotFound();
          }
            return await _context.SensitiveLists.ToListAsync();
        }

        // GET: api/SensitiveLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SensitiveList>> GetSensitiveList(long id)
        {
          if (_context.SensitiveLists == null)
          {
              return NotFound();
          }
            var sensitiveList = await _context.SensitiveLists.FindAsync(id);

            if (sensitiveList == null)
            {
                return NotFound();
            }

            return sensitiveList;
        }

        // PUT: api/SensitiveLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensitiveList(long id, SensitiveList sensitiveList)
        {
            if (id != sensitiveList.RowId)
            {
                return BadRequest();
            }

            _context.Entry(sensitiveList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensitiveListExists(id))
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

        // POST: api/SensitiveLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SensitiveList>> PostSensitiveList(SensitiveList sensitiveList)
        {
          if (_context.SensitiveLists == null)
          {
              return Problem("Entity set 'FlashContext.SensitiveLists'  is null.");
          }
            _context.SensitiveLists.Add(sensitiveList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensitiveList", new { id = sensitiveList.RowId }, sensitiveList);
        }

        // DELETE: api/SensitiveLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensitiveList(long id)
        {
            if (_context.SensitiveLists == null)
            {
                return NotFound();
            }
            var sensitiveList = await _context.SensitiveLists.FindAsync(id);
            if (sensitiveList == null)
            {
                return NotFound();
            }

            _context.SensitiveLists.Remove(sensitiveList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SensitiveListExists(long id)
        {
            return (_context.SensitiveLists?.Any(e => e.RowId == id)).GetValueOrDefault();
        }

        [HttpGet("MaskMessageAsync")]
        public async Task<IEnumerable<GET_MASKED_MESSAGEResult>> GET_MASKED_MESSAGEAsync (string? message)
        {
            return await _context.GetProcedures().GET_MASKED_MESSAGEAsync(message);
        }


    }
}
