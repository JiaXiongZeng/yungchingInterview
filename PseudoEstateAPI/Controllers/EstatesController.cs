using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PseudoEstateAPI.Entities;

namespace PseudoEstateAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstatesController : ControllerBase
    {
        private readonly YungchingInterviewContext _context;

        public EstatesController(YungchingInterviewContext context)
        {
            _context = context;
        }

        // GET: /Estates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estate>>> GetEstates()
        {
          if (_context.Estates == null)
          {
              return NotFound();
          }
            return await _context.Estates.ToListAsync();
        }

        // GET: /Estates/P0001
        [HttpGet("{estateId}")]
        public async Task<ActionResult<Estate>> GetEstate(string estateId)
        {
          if (_context.Estates == null)
          {
              return NotFound();
          }
            var estate = await _context.Estates.FirstOrDefaultAsync(x => x.EstateId == estateId);

            if (estate == null)
            {
                return NotFound();
            }

            return estate;
        }

        // PUT: /Estates/P0001
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{estateId}")]
        public async Task<IActionResult> PutEstate(string estateId, Estate estate)
        {
            if (estateId != estate.EstateId)
            {
                return BadRequest();
            }

            _context.Entry(estate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstateExists(estateId))
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

        // POST: /Estates/P0001
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estate>> PostEstate(Estate estate)
        {
          if (_context.Estates == null)
          {
              return Problem("Entity set 'YungchingInterviewContext.Estates'  is null.");
          }
            _context.Estates.Add(estate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstate", new { estateId = estate.EstateId }, estate);
        }

        // DELETE: /Estates/P0001
        [HttpDelete("{estateId}")]
        public async Task<IActionResult> DeleteEstate(string estateId)
        {
            if (_context.Estates == null)
            {
                return NotFound();
            }
            var estate = await _context.Estates.FirstOrDefaultAsync(x => x.EstateId == estateId);
            if (estate == null)
            {
                return NotFound();
            }

            //After testing, we found it a mistake to truly delete the record
            //_context.Estates.Remove(estate);
            estate.DeleteId = "LogInID";
            estate.DeleteName = "LogInName";
            estate.DeleteDtm = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstateExists(string estateId)
        {
            return (_context.Estates?.Any(e => e.EstateId == estateId)).GetValueOrDefault();
        }
    }
}
