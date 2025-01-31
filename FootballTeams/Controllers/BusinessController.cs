using Microsoft.AspNetCore.Mvc;
using FootballTeams.BL.Interfaces;
using FootballTeams.Models.DTO;
using FootballTeams.Models.Requests;
using FootballTeams.Models.Responses;


namespace FootballTeams.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService _teamservice;

        public BusinessController(IBusinessService teamservice)
        {
            _teamservice = teamservice;
        }

        [HttpGet("GetAllTeamsByPlayers")]
        public TeamsFullDetailsResponse? GetAllTeamsByPlayers(AddTeamRequest request)
        {
            return _teamservice.GetAllTeamsByPlayers(request);
        }
    }
}
