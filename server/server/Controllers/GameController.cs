using Base.Model.Card;
using Base.Model.Common;
using Base.Service;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : BaseController
    {
        private IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        async public Task<ActionResult> GetNewGame()
        {
            try
            {
                return Ok(await _gameService.start());

            }
            catch (Exception e)
            {

                return ISE(e);
            }
        }

        [HttpPost]
        async public Task<ActionResult> FlipCard(CardFlipModel model )
        {
            try
            {
                var result = await _gameService.FlipCard(model);
                if (result.Success) { return Ok(result); }
                return BadRequest(result);
            }
            catch (Exception e)
            {

                return ISE(e);
            }
        }
    }
}
