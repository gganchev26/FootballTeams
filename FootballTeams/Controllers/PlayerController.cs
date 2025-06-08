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
        public async Task<IActionResult> GetAll()
        {
            var players = await _playerService.GetAllAsync();
            return Ok(players);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var player = await _playerService.GetByIdAsync(id);
            if (player == null)
            {
                return NotFound($"Player with ID {id} not found.");
            }
            return Ok(player);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Players player)
        {
            await _playerService.AddAsync(player);
            return Ok("Player added successfully.");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var player = await _playerService.GetByIdAsync(id);
            if (player == null)
            {
                return NotFound($"Player with ID {id} not found.");
            }

            await _playerService.DeleteAsync(id);
            return Ok("Player deleted successfully.");
        }
    }
}
