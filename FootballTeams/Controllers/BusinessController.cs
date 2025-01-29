using Microsoft.AspNetCore.Mvc;
using FootballTeams.BL.Interfaces;
using FootballTeams.Models.DTO;
using FootballTeams.Models.Requests;


namespace FootballTeams.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService _teamService;
        public BusinessController(IBusinessService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet("GetAllDetailedTeams")]
        public IActionResult GetAllDetailedTeams()
        {
            var result = _teamService.GetAllTeams();

            if (result != null && result.Count > 0)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("Test")]
        public IActionResult Test([FromBody] TestRequest teams) 
        {
            return Ok();
        }
    }
    public class TestRequest
    {
        public int MagicNumber { get; set; }
        public string Description { get; set; }

        public DateTime DateTime { get; set; }
    }
}
