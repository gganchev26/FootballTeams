using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using FootballTeams.BL.Interfaces;
using FootballTeams.Models.DTO;
using FootballTeams.Models.Requests;


namespace FootballTeams.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService _teamsService;
        private readonly IMapper _mapper;

        public TeamsController(ITeamsService teamservice, IMapper mapper)
        {
            _teamsService = teamservice;
            _mapper = mapper;
        }
        
        [HttpGet("GetAll")]
        public IActionResult GetAll() 
        {
        var result = _teamsService.GetAll();

            if (result != null && result.Count > 0) {
                return Ok(result);
            }
            return NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest($"Wrong ID: {id}");
            }
            var result = _teamsService.GetById(id);
            
            if (result == null)
            {
                return NotFound($"Team with ID:{id} not found");
            }
            
            return Ok(result);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody]AddTeamRequest team)
        {
            var teamDto = _mapper.Map<Teams>(team);

            _teamsService.Add(teamDto);

            return Ok();
        }

        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            //return _teamsService.GetById(id);
        }
    }
}
