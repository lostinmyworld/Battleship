using Api.Battle.DataTypes.Requests;
using Api.Battle.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Battleship.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BattleshipController : ControllerBase
    {
        private readonly IGameService _gameService;

        public BattleshipController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("newGame")]
        public async Task<IActionResult> CreateNewGame([FromBody] CreateGameRequest request)
        {
            var result = await _gameService.CreateGameSession(request).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost("deployShips")]
        public async Task<IActionResult> DeployShips([FromBody] DeployShipsRequest request)
        {
            var result = await _gameService.DeployShips(request).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost("hit")]
        public async Task<IActionResult> Hit([FromBody] HitRequest request)
        {
            var result = await _gameService.CannonBallHit(request);

            return Ok(result);
        }
    }
}
