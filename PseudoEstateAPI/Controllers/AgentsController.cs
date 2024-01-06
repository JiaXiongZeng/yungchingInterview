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
    public class AgentsController : ControllerBase
    {
        private readonly YungchingInterviewContext _context;

        public AgentsController(YungchingInterviewContext context)
        {
            _context = context;
        }

        // GET: /Agents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agent>>> GetAgents()
        {
          if (_context.Agents == null)
          {
              return NotFound();
          }
            return await _context.Agents.ToListAsync();
        }

        // GET: /Agents/A0001
        [HttpGet("{agentId}")]
        public async Task<ActionResult<Agent>> GetAgent(string agentId)
        {
          if (_context.Agents == null)
          {
              return NotFound();
          }
            var agent = await _context.Agents.FirstOrDefaultAsync(x => x.AgentId == agentId);

            if (agent == null)
            {
                return NotFound();
            }

            return agent;
        }

        // PUT: /Agents/A0001
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{agentId}")]
        public async Task<IActionResult> PutAgent(string agentId, Agent agent)
        {
            if (agentId != agent.AgentId)
            {
                return BadRequest();
            }

            _context.Entry(agent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgentExists(agentId))
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

        // POST: /Agents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Agent>> PostAgent(Agent agent)
        {
          if (_context.Agents == null)
          {
              return Problem("Entity set 'YungchingInterviewContext.Agents'  is null.");
          }
            _context.Agents.Add(agent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgent", new { agentId = agent.AgentId }, agent);
        }

        // DELETE: /Agents/A0001
        [HttpDelete("{agentId}")]
        public async Task<IActionResult> DeleteAgent(string agentId)
        {
            if (_context.Agents == null)
            {
                return NotFound();
            }
            var agent = await _context.Agents.FirstOrDefaultAsync(x => x.AgentId == agentId);
            if (agent == null)
            {
                return NotFound();
            }

            _context.Agents.Remove(agent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgentExists(string agentId)
        {
            return (_context.Agents?.Any(e => e.AgentId == agentId)).GetValueOrDefault();
        }
    }
}
