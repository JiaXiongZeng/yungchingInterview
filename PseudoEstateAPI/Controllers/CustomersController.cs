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
    public class CustomersController : ControllerBase
    {
        private readonly YungchingInterviewContext _context;

        public CustomersController(YungchingInterviewContext context)
        {
            _context = context;
        }

        // GET: /Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            return await _context.Customers.ToListAsync();
        }

        // GET: /Customers/C0001
        [HttpGet("{customerId}")]
        public async Task<ActionResult<Customer>> GetCustomer(string customerId)
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: /Customers/C0001
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{customerId}")]
        public async Task<IActionResult> PutCustomer(string customerId, Customer customer)
        {
            if (customerId != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(customerId))
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

        // POST: /Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
          if (_context.Customers == null)
          {
              return Problem("Entity set 'YungchingInterviewContext.Customers'  is null.");
          }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { customerId = customer.CustomerId }, customer);
        }

        // DELETE: /Customers/C0001
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(string customerId)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(string customerId)
        {
            return (_context.Customers?.Any(e => e.CustomerId == customerId)).GetValueOrDefault();
        }
    }
}
