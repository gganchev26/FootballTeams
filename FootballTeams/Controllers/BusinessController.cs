using FootballTeams.BL.Interfaces;
using FootballTeams.Models.Request;
using FootballTeams.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FootballTeam.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService _businessService;

        public BusinessController(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        [HttpPost("GetAllTeamsById")]
        public async Task<IActionResult> GetAllTeamsByIdAsync([FromBody] AddTeamRequest request)
        {
            var result = await _businessService.GetAllTeamsByIdAsync(request);

            if (result == null)
                return NotFound($"No data found for player ID {request.Id} and team {request.TeamName}");

            return Ok(result);
        }

        [HttpGet("GetAllTeamsCount")]
        public async Task<IActionResult> GetAllTeamsCountAsync(int inputCount, int playerId)
        {
            var result = await _businessService.GetAllTeamsCountAsync(inputCount, playerId);
            return Ok(result);
        }
    }
}
