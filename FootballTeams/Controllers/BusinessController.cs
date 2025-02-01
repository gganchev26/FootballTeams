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
        public TeamsFullDetails? GetAllTeamsById([FromBody] AddTeamRequest request)
        {
            return _businessService.GetAllTeamsById(request);
        }
    }
}