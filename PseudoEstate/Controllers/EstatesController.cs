using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PseudoEstate.Entities;

namespace PseudoEstate.Controllers
{
    public class EstatesController : Controller
    {
        private readonly YungchingInterviewContext _context;

        public EstatesController(YungchingInterviewContext context)
        {
            _context = context;
        }

        // GET: Estates
        public async Task<IActionResult> Index()
        {
              return _context.Estates != null ? 
                          View(await _context.Estates.ToListAsync()) :
                          Problem("Entity set 'YungchingInterviewContext.Estates'  is null.");
        }

        // GET: Estates/Details/E0001
        [Route("[Controller]/[Action]/{estateId}")]
        public async Task<IActionResult> Details(string estateId)
        {
            if (estateId == null || _context.Estates == null)
            {
                return NotFound();
            }

            var estate = await _context.Estates
                .FirstOrDefaultAsync(m => m.EstateId == estateId);
            if (estate == null)
            {
                return NotFound();
            }

            return View(estate);
        }

        // GET: Estates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstateId,Name,Description,BuildType,Address,SquareMeters,TotalPrice,Owner,AgentId,Status,OnlineDtm,CreateId,CreateName,CreateDtm,ModifyId,ModifyName,ModifyDtm,DeleteId,DeleteName,DeleteDtm")] Estate estate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estate);
        }

        // GET: Estates/Edit/E0001
        [Route("[Controller]/[Action]/{estateId}")]
        public async Task<IActionResult> Edit(string estateId)
        {
            if (estateId == null || _context.Estates == null)
            {
                return NotFound();
            }

            var estate = await _context.Estates.FirstOrDefaultAsync(x => x.EstateId == estateId);
            if (estate == null)
            {
                return NotFound();
            }
            return View(estate);
        }

        // POST: Estates/Edit/E0001
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]/{estateId}")]
        public async Task<IActionResult> Edit(string estateId, [Bind("Id,EstateId,Name,Description,BuildType,Address,SquareMeters,TotalPrice,Owner,AgentId,Status,OnlineDtm,CreateId,CreateName,CreateDtm,ModifyId,ModifyName,ModifyDtm,DeleteId,DeleteName,DeleteDtm")] Estate estate)
        {
            if (estateId != estate.EstateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstateExists(estate.EstateId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estate);
        }

        // GET: Estates/Delete/E0001
        [Route("[Controller]/[Action]/{estateId}")]
        public async Task<IActionResult> Delete(string estateId)
        {
            if (estateId == null || _context.Estates == null)
            {
                return NotFound();
            }

            var estate = await _context.Estates
                .FirstOrDefaultAsync(m => m.EstateId == estateId);
            if (estate == null)
            {
                return NotFound();
            }

            return View(estate);
        }

        // POST: Estates/Delete/E0001
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]/{estateId}")]
        public async Task<IActionResult> DeleteConfirmed(string estateId)
        {
            if (_context.Estates == null)
            {
                return Problem("Entity set 'YungchingInterviewContext.Estates'  is null.");
            }
            var estate = await _context.Estates.FirstOrDefaultAsync(x => x.EstateId == estateId);
            if (estate != null)
            {
                _context.Estates.Remove(estate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstateExists(string estateId)
        {
          return (_context.Estates?.Any(e => e.EstateId == estateId)).GetValueOrDefault();
        }
    }
}
