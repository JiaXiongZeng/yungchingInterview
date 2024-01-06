using Microsoft.AspNetCore.Mvc;

namespace PseudoEstate.Controllers
{
    public class ReportController : BaseController
    {
        public ReportController(SwaggerClient swaggerClient) : base(swaggerClient)
        {
            //Other implementations
        }

        public async Task<IActionResult> Index()
        {
            return View(await _api.ReportAllAsync());
        }

        [Route("[Controller]/[Action]/{agentId}")]
        public async Task<IActionResult> ByAgent(string agentId)
        {
            if (string.IsNullOrEmpty(agentId))
            {
                return NotFound();
            }

            return View(await _api.ReportByAgentAsync(agentId));
        }
    }
}
