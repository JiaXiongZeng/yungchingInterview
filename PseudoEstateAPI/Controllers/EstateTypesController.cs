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
    public class EstateTypesController : ControllerBase
    {
        private readonly YungchingInterviewContext _context;

        public EstateTypesController(YungchingInterviewContext context)
        {
            _context = context;
        }

        // GET: /EstateTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstateType>>> GetEstateTypes()
        {
          if (_context.EstateTypes == null)
          {
              return NotFound();
          }
            return await _context.EstateTypes.ToListAsync();
        }

        // GET: /EstateTypes/T0001
        [HttpGet("{typeId}")]
        public async Task<ActionResult<EstateType>> GetEstateType(string typeId)
        {
          if (_context.EstateTypes == null)
          {
              return NotFound();
          }
            var estateType = await _context.EstateTypes.FirstOrDefaultAsync(x => x.TypeId == typeId);

            if (estateType == null)
            {
                return NotFound();
            }

            return estateType;
        }

        // PUT: /EstateTypes/T0001
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{typeId}")]
        public async Task<IActionResult> PutEstateType(string typeId, EstateType estateType)
        {
            if (typeId != estateType.TypeId)
            {
                return BadRequest();
            }

            _context.Entry(estateType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstateTypeExists(typeId))
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

        // POST: /EstateTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstateType>> PostEstateType(EstateType estateType)
        {
          if (_context.EstateTypes == null)
          {
              return Problem("Entity set 'YungchingInterviewContext.EstateTypes'  is null.");
          }
            _context.EstateTypes.Add(estateType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstateType", new { typeId = estateType.TypeId }, estateType);
        }

        // DELETE: /EstateTypes/T0001
        [HttpDelete("{typeId}")]
        public async Task<IActionResult> DeleteEstateType(string typeId)
        {
            if (_context.EstateTypes == null)
            {
                return NotFound();
            }
            var estateType = await _context.EstateTypes.FirstOrDefaultAsync(x => x.TypeId == typeId);
            if (estateType == null)
            {
                return NotFound();
            }

            _context.EstateTypes.Remove(estateType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstateTypeExists(string typeId)
        {
            return (_context.EstateTypes?.Any(e => e.TypeId == typeId)).GetValueOrDefault();
        }
    }
}
