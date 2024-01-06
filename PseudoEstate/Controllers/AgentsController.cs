using Microsoft.AspNetCore.Mvc;

namespace PseudoEstate.Controllers
{
    public class AgentsController : BaseController
    {
        public AgentsController(SwaggerClient api): base(api)  {
            //Other implementations
        }

        // GET: Agents
        public async Task<IActionResult> Index()
        {
            return View(await _api.AgentsAllAsync());
        }

        // GET: Agents/Details/A0001
        [Route("[Controller]/[Action]/{agentId}")]
        public async Task<IActionResult> Details(string agentId)
        {
            if (agentId == null)
            {
                return NotFound();
            }

            var agent = await _api.AgentsGETAsync(agentId);
            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }

        // GET: Agents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgentId,Name,Title,PhoneNo,Licenses,CreateId,CreateName,CreateDtm,ModifyId,ModifyName,ModifyDtm,DeleteId,DeleteName,DeleteDtm")] Agent agent)
        {
            if (ModelState.IsValid)
            {
                await _api.AgentsPOSTAsync(agent);
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }

        // GET: Agents/Edit/A0001
        [Route("[Controller]/[Action]/{agentId}")]
        public async Task<IActionResult> Edit(string agentId)
        {
            if (agentId == null)
            {
                return NotFound();
            }

            var agent = await _api.AgentsGETAsync(agentId);
            if (agent == null)
            {
                return NotFound();
            }
            return View(agent);
        }

        // POST: Agents/Edit/A0001
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]/{agentId}")]
        public async Task<IActionResult> Edit(string agentId, [Bind("Id,AgentId,Name,Title,PhoneNo,Licenses,CreateId,CreateName,CreateDtm,ModifyId,ModifyName,ModifyDtm,DeleteId,DeleteName,DeleteDtm")] Agent agent)
        {
            if (agentId != agent.AgentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _api.AgentsPUTAsync(agentId, agent);
                }
                catch (Exception)
                {
                    if (!await AgentExists(agent.AgentId))
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
            return View(agent);
        }

        // GET: Agents/Delete/A0001
        [Route("[Controller]/[Action]/{agentId}")]
        public async Task<IActionResult> Delete(string agentId)
        {
            if (agentId == null)
            {
                return NotFound();
            }

            var agent = await _api.AgentsGETAsync(agentId);
            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }

        // POST: Agents/Delete/A0001
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]/{agentId}")]
        public async Task<IActionResult> DeleteConfirmed(string agentId)
        {
            var agent = await _api.AgentsGETAsync(agentId);
            if (agent != null)
            {
                await _api.AgentsDELETEAsync(agentId);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AgentExists(string agentId)
        {
            var agent = await _api.AgentsGETAsync(agentId);
            return (agent != null);
        }
    }
}
