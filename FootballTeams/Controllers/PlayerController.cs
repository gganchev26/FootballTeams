using FootballTeams.BL.Interfaces;
using FootballTeams.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FootballTeam.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Players> GetAll()
        {
            return _playerService.GetAll();
        }

        [HttpGet("GetById")]
        public Players? GetById(int id)
        {
            return _playerService.GetById(id);
        }

        [HttpPost("Add")]
        public void Add([FromBody] Players player)
        {
            _playerService.Add(player);
        }

        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            _playerService.Delete(id);
        }
    }
}