using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PseudoEstateAPI.Entities;
using PseudoEstateAPI.Models;
using System.Security.Policy;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PseudoEstateAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly YungchingInterviewContext _context;

        public ReportController(YungchingInterviewContext context)
        {
            _context = context;
        }

        // GET: /ReportAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> GetReport()
        {
            var query = queryReportAll();
            return (await query.ToListAsync());
        }

        // GET: /ReportByAgent/A0001
        [HttpGet("{agentId}")]
        public async Task<ActionResult<IEnumerable<Report>>> GetReport(string agentId)
        {
            if (string.IsNullOrEmpty(agentId))
            {
                return NotFound();
            }

            var query = queryReportAll().Where(x => x.AgentId == agentId);
            return (await query.ToListAsync());
        }

        private IQueryable<Report> queryReportAll()
        {
            var query =
                from estate in _context.Estates
                join agent in _context.Agents
                on estate.AgentId equals agent.AgentId
                join customer in _context.Customers
                on estate.Owner equals customer.CustomerId
                join estateType in _context.EstateTypes
                on estate.BuildType equals estateType.TypeId
                select new Report
                {
                    EstateId = estate.EstateId,
                    BuildType = estateType.Desc,
                    EstateDescription = estate.Description,
                    OnlineDtm = estate.OnlineDtm,
                    Address = estate.Address,
                    SquareMeters = estate.SquareMeters,
                    Status = estate.Status,
                    TotalPrice = estate.TotalPrice,
                    OwnerId = customer.CustomerId,
                    OwnerName = customer.Name,
                    OwnerPhoneNo = customer.PhoneNo,
                    OwnerEmail = customer.Email,
                    AgentId = agent.AgentId,
                    AgentName = agent.Name,
                    AgentTitle = agent.Title,
                    AgentPhoneNo = agent.PhoneNo,
                    AgentLicenses = agent.Licenses
                };
            return query;
        }
    }
}
