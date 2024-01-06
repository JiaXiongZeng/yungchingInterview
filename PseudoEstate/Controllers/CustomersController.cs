using Microsoft.AspNetCore.Mvc;

namespace PseudoEstate.Controllers
{
    public class CustomersController : Controller
    {
        private readonly SwaggerClient _api;

        public CustomersController(SwaggerClient api)
        {
            _api = api;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _api.CustomersAllAsync());
        }

        // GET: Customers/Details/C0001
        [Route("[Controller]/[Action]/{customerId}")]
        public async Task<IActionResult> Details(string customerId)
        {
            if (customerId == null)
            {
                return NotFound();
            }

            var customer = await _api.CustomersGETAsync(customerId);
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
                await _api.CustomersPOSTAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/C0001
        [Route("[Controller]/[Action]/{customerId}")]
        public async Task<IActionResult> Edit(string customerId)
        {
            if (customerId == null)
            {
                return NotFound();
            }

            var customer = await _api.CustomersGETAsync(customerId);
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
                    await _api.CustomersPUTAsync(customerId, customer);
                }
                catch (Exception)
                {
                    if (!await CustomerExists(customer.CustomerId))
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
            if (customerId == null)
            {
                return NotFound();
            }

            var customer = await _api.CustomersGETAsync(customerId);
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
            var customer = await _api.CustomersGETAsync(customerId);
            if (customer != null)
            {
                await _api.CustomersDELETEAsync(customerId);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CustomerExists(string customerId)
        {
            var customer = await _api.CustomersGETAsync(customerId);
            return (customer != null);
        }
    }
}
