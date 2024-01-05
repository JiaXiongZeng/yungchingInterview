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
    public class EstateTypesController : Controller
    {
        private readonly YungchingInterviewContext _context;

        public EstateTypesController(YungchingInterviewContext context)
        {
            _context = context;
        }

        // GET: EstateTypes
        public async Task<IActionResult> Index()
        {
              return _context.EstateTypes != null ? 
                          View(await _context.EstateTypes.ToListAsync()) :
                          Problem("Entity set 'YungchingInterviewContext.EstateTypes'  is null.");
        }

        // GET: EstateTypes/Details/T0001
        [Route("[Controller]/[Action]/{typeId}")]
        public async Task<IActionResult> Details(string typeId)
        {
            if (typeId == null || _context.EstateTypes == null)
            {
                return NotFound();
            }

            var estateType = await _context.EstateTypes
                .FirstOrDefaultAsync(m => m.TypeId == typeId);
            if (estateType == null)
            {
                return NotFound();
            }

            return View(estateType);
        }

        // GET: EstateTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstateTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeId,Desc,IsEnable,CreateId,CreateName,CreateDtm,ModifyId,ModifyName,ModifyDtm,DeleteId,DeleteName,DeleteDtm")] EstateType estateType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estateType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estateType);
        }

        // GET: EstateTypes/Edit/T0001
        [Route("[Controller]/[Action]/{typeId}")]
        public async Task<IActionResult> Edit(string typeId)
        {
            if (typeId == null || _context.EstateTypes == null)
            {
                return NotFound();
            }

            var estateType = await _context.EstateTypes.FirstOrDefaultAsync(x => x.TypeId == typeId);
            if (estateType == null)
            {
                return NotFound();
            }
            return View(estateType);
        }

        // POST: EstateTypes/Edit/T0001
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]/{typeId}")]
        public async Task<IActionResult> Edit(string typeId, [Bind("Id,TypeId,Desc,IsEnable,CreateId,CreateName,CreateDtm,ModifyId,ModifyName,ModifyDtm,DeleteId,DeleteName,DeleteDtm")] EstateType estateType)
        {
            if (typeId != estateType.TypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estateType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstateTypeExists(estateType.TypeId))
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
            return View(estateType);
        }

        // GET: EstateTypes/Delete/T0001
        [Route("[Controller]/[Action]/{typeId}")]
        public async Task<IActionResult> Delete(string typeId)
        {
            if (typeId == null || _context.EstateTypes == null)
            {
                return NotFound();
            }

            var estateType = await _context.EstateTypes
                .FirstOrDefaultAsync(m => m.TypeId == typeId);
            if (estateType == null)
            {
                return NotFound();
            }

            return View(estateType);
        }

        // POST: EstateTypes/Delete/T0001
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]/{typeId}")]
        public async Task<IActionResult> DeleteConfirmed(string typeId)
        {
            if (_context.EstateTypes == null)
            {
                return Problem("Entity set 'YungchingInterviewContext.EstateTypes'  is null.");
            }
            var estateType = await _context.EstateTypes.FirstOrDefaultAsync(x => x.TypeId == typeId);
            if (estateType != null)
            {
                _context.EstateTypes.Remove(estateType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstateTypeExists(string typeId)
        {
          return (_context.EstateTypes?.Any(e => e.TypeId == typeId)).GetValueOrDefault();
        }
    }
}
