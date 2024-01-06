using Microsoft.AspNetCore.Mvc;

namespace PseudoEstate.Controllers
{
    public class EstatesController : Controller
    {
        private readonly SwaggerClient _api;

        public EstatesController(SwaggerClient api)
        {
            _api = api;
        }

        // GET: Estates
        public async Task<IActionResult> Index()
        {
            return View(await _api.EstatesAllAsync());
        }

        // GET: Estates/Details/E0001
        [Route("[Controller]/[Action]/{estateId}")]
        public async Task<IActionResult> Details(string estateId)
        {
            if (estateId == null)
            {
                return NotFound();
            }

            var estate = await _api.EstatesGETAsync(estateId);
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
                await _api.EstatesPOSTAsync(estate);
                return RedirectToAction(nameof(Index));
            }
            return View(estate);
        }

        // GET: Estates/Edit/E0001
        [Route("[Controller]/[Action]/{estateId}")]
        public async Task<IActionResult> Edit(string estateId)
        {
            if (estateId == null)
            {
                return NotFound();
            }

            var estate = await _api.EstatesGETAsync(estateId);
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
                    await _api.EstatesPUTAsync(estateId, estate);
                }
                catch (Exception)
                {
                    if (!await EstateExists(estate.EstateId))
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
            if (estateId == null)
            {
                return NotFound();
            }

            var estate = await _api.EstatesGETAsync(estateId);
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
            var estate = await _api.EstatesGETAsync(estateId);
            if (estate != null)
            {
                await _api.EstatesDELETEAsync(estateId);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EstateExists(string estateId)
        {
            var estate = await _api.EstatesGETAsync(estateId);
            return (estate != null);
        }
    }
}
