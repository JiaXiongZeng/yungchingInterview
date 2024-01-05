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
    public class AgentsController : Controller
    {
        private readonly YungchingInterviewContext _context;

        public AgentsController(YungchingInterviewContext context)
        {
            _context = context;
        }

        // GET: Agents
        public async Task<IActionResult> Index()
        {
            return _context.Agents != null ?
                        View(await _context.Agents.ToListAsync()) :
                        Problem("Entity set 'YungchingInterviewContext.Agents'  is null.");
        }

        // GET: Agents/Details/A0001
        [Route("[Controller]/[Action]/{agentId}")]
        public async Task<IActionResult> Details(string agentId)
        {
            if (agentId == null || _context.Agents == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents
                .FirstOrDefaultAsync(m => m.AgentId == agentId);
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
                _context.Add(agent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }

        // GET: Agents/Edit/A0001
        [Route("[Controller]/[Action]/{agentId}")]
        public async Task<IActionResult> Edit(string agentId)
        {
            if (agentId == null || _context.Agents == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents.FirstOrDefaultAsync(x => x.AgentId == agentId);
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
        public async Task<IActionResult> Edit(string agentId, [Bind("AgentId,Name,Title,PhoneNo,Licenses,CreateId,CreateName,CreateDtm,ModifyId,ModifyName,ModifyDtm,DeleteId,DeleteName,DeleteDtm")] Agent agent)
        {
            if (agentId != agent.AgentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgentExists(agent.AgentId))
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
            if (agentId == null || _context.Agents == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents
                .FirstOrDefaultAsync(m => m.AgentId == agentId);
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
            if (_context.Agents == null)
            {
                return Problem("Entity set 'YungchingInterviewContext.Agents'  is null.");
            }
            var agent = await _context.Agents.FirstOrDefaultAsync(x => x.AgentId == agentId);
            if (agent != null)
            {
                _context.Agents.Remove(agent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgentExists(string agentId)
        {
            return (_context.Agents?.Any(e => e.AgentId == agentId)).GetValueOrDefault();
        }
    }
}
