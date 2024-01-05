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
    public class CustomersController : Controller
    {
        private readonly YungchingInterviewContext _context;

        public CustomersController(YungchingInterviewContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
              return _context.Customers != null ? 
                          View(await _context.Customers.ToListAsync()) :
                          Problem("Entity set 'YungchingInterviewContext.Customers'  is null.");
        }

        // GET: Customers/Details/C0001
        [Route("[Controller]/[Action]/{customerId}")]
        public async Task<IActionResult> Details(string customerId)
        {
            if (customerId == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == customerId);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,Name,PhoneNo,Email,CreateId,CreateName,CreateDtm,ModifyId,ModifyName,ModifyDtm,DeleteId,DeleteName,DeleteDtm")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/C0001
        [Route("[Controller]/[Action]/{customerId}")]
        public async Task<IActionResult> Edit(string customerId)
        {
            if (customerId == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/C0001
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]/{customerId}")]
        public async Task<IActionResult> Edit(string customerId, [Bind("Id,CustomerId,Name,PhoneNo,Email,CreateId,CreateName,CreateDtm,ModifyId,ModifyName,ModifyDtm,DeleteId,DeleteName,DeleteDtm")] Customer customer)
        {
            if (customerId != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            return View(customer);
        }

        // GET: Customers/Delete/C0001
        [Route("[Controller]/[Action]/{customerId}")]
        public async Task<IActionResult> Delete(string customerId)
        {
            if (customerId == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == customerId);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/C0001
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]/{customerId}")]
        public async Task<IActionResult> DeleteConfirmed(string customerId)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'YungchingInterviewContext.Customers'  is null.");
            }
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(string customerId)
        {
          return (_context.Customers?.Any(e => e.CustomerId == customerId)).GetValueOrDefault();
        }
    }
}
