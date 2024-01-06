using Microsoft.AspNetCore.Mvc;

namespace PseudoEstate.Controllers
{
    public class EstateTypesController : BaseController
    {
        public EstateTypesController(SwaggerClient api): base(api)
        {
            //Other implementations
        }

        // GET: EstateTypes
        public async Task<IActionResult> Index()
        {
            return View(await _api.EstateTypesAllAsync());
        }

        // GET: EstateTypes/Details/T0001
        [Route("[Controller]/[Action]/{typeId}")]
        public async Task<IActionResult> Details(string typeId)
        {
            if (typeId == null)
            {
                return NotFound();
            }

            var estateType = await _api.EstateTypesGETAsync(typeId);
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
                await _api.EstateTypesPOSTAsync(estateType);
                return RedirectToAction(nameof(Index));
            }
            return View(estateType);
        }

        // GET: EstateTypes/Edit/T0001
        [Route("[Controller]/[Action]/{typeId}")]
        public async Task<IActionResult> Edit(string typeId)
        {
            if (typeId == null)
            {
                return NotFound();
            }

            var estateType = await _api.EstateTypesGETAsync(typeId);
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
                    await _api.EstateTypesPUTAsync(typeId, estateType);
                }
                catch (Exception)
                {
                    if (!await EstateTypeExists(estateType.TypeId))
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
            if (typeId == null)
            {
                return NotFound();
            }

            var estateType = await _api.EstateTypesGETAsync(typeId);
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
            var estateType = await _api.EstateTypesGETAsync(typeId);
            if (estateType != null)
            {
                await _api.EstateTypesDELETEAsync(typeId);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EstateTypeExists(string typeId)
        {
            var estateType = await _api.EstateTypesGETAsync(typeId);
            return (estateType != null);
        }
    }
}
