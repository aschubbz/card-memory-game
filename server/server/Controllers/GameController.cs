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

        /// <summary>
        /// Create new game
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/start")]
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

        /// <summary>
        /// Flip a card
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("/flip")]
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

        /// <summary>
        /// Get last game
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/game/{id}")]
        async public Task<ActionResult>GetGame(int id)
        {
            var result = await _gameService.getById(id);
            if (result.success)
                return Ok(result);

            return BadRequest(result);
        }

        /// <summary>
        /// End game
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/end-game")]
        async public Task<ActionResult> EndGame(int id)
        {
            return Ok();
        }
    }
}
