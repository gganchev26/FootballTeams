using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using FootballTeams.BL.Interfaces;
using FootballTeams.Models.DTO;
using FootballTeams.Models.Requests;


namespace FootballTeams.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerservice;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerService playerservice, IMapper mapper)
        {
            _playerservice = playerservice;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Players> GetAll([FromBody]Players dto)
        {
            return _playerservice.GetAll();
        }

        [HttpGet("GetById")]
        public Players? GetById(int id)
        {
            return _playerservice.GetById(id);
        }

        [HttpPost("Add")]
        public void Add([FromBody]Players players) 
        { 
            _playerservice.Add(players);
        }

        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            _playerservice.Delete(id);
        }
    }
}
