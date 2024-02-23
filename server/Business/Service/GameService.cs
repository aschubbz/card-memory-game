using AutoMapper;
using Base.Model.Card;
using Base.Model.Common;
using Base.Model.Game;
using Base.Model.Player;
using Base.Service;
using DAL.Enum;
using DAL.Model;
using DAL.Repository.Abstract;

namespace Business.Service
{
    internal class GameService : IGameService
    {
        ICardRepository _cardRepository;
        private IGamePlayerRepository _gamePlayerRepository;
        private IPlayerRepository _playerRepository;
        private IGameRepository _gameRepository;
        private IGameCardRepository _gameCardRepository;

        public GameService(
            ICardRepository cardRepository,
            IGameRepository gameRepository,
            IPlayerRepository playerRepository,
            IGamePlayerRepository gamePlayerRepository,
            IGameCardRepository gameCardRepository
            )
        {
            _cardRepository = cardRepository;
            _gamePlayerRepository = gamePlayerRepository;
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
            _gameCardRepository = gameCardRepository;
        }
        async public Task<ResponseWithDataModel<GameViewModel>>start()
        {
            // get random 20 cards
            var list = (await _cardRepository.GetRandomCards(20)).Select(o => new CardViewModel { Id=o.Id, Image= o.Image }).ToList();

            // get players
            var players = await _playerRepository.Get();

            // create game

            var game = new Game { Sate = GameState.STARTED };
            var new_game = await _gameRepository.Create(game);


            // create game cards for game
            var game_cards = new List<GameCard>();
            int order = 0;
            foreach (var card in list)
            {
                game_cards.Add(new GameCard
                {
                    FlipedState = FlipState.NOT_FLIPED,
                    CardId = card.Id,
                    GameId = new_game.Id,
                    Order = order+1,
                    FlippedOrder = null
                });

                order++;
            }

            // create game players
            var game_payers = new List<GamePlayer>();
            var _players = new List<GamePlayerViewModel>();

            foreach (var item in players)
            {
                game_payers.Add(new GamePlayer
                {
                    PlayerId = item.Id,
                    Score = 0,
                    GameId = new_game.Id,
                });

                _players.Add(new GamePlayerViewModel { Score = 0, PlayerId = item.Id, Name = item.Name });
            }

            await _gamePlayerRepository.Create(game_payers);
            await _gameCardRepository.Create(game_cards);

           var _cards = (await _gameCardRepository.ByGame(game.Id)).Select(c => new GameCardViewModel { 
               Image = c.Card.Image, 
               ImageDefault= "purple_back.png", 
               CardType=c.Card.CardType, 
               Id =c.Id}
           ).ToList();


            var game_view_model = new GameViewModel { Card = _cards, Player = _players };
            game_view_model.Id = new_game.Id;
            return new ResponseWithDataModel<GameViewModel>() { Data = game_view_model, success=true, Message= "New game has created" };
        }

        async public Task<CardFlipedResultModel> FlipCard(CardFlipModel model)
        {
           var cards = (await _gameCardRepository.GetById(model.gameCardIds)).ToList();

            if (cards.Count == 0)
            {
                return new CardFlipedResultModel { Success = false, Message = "Invalid cards have detected" };
            }
            
            var player = await _gamePlayerRepository.GetByGameAndPlayerId(cards[0].GameId, model.playerId);

            foreach (var item in cards)
            {
                if (item.FlippedPlayerId != null)
                {
                    return new CardFlipedResultModel { Success = false, Message = "Invalid cards have detected" };
                }
                item.IsMatch = Matched.MATCHED;
                item.FlippedPlayerId = model.playerId;
            }


            player.Score = player.Score + 1;

            // TODO: add transaction
            _gameCardRepository.Update(cards);
            _gamePlayerRepository.Update(player);

            return new CardFlipedResultModel { Success = true, Message = " Game state has recorded" };

        }

        async public Task<ResponseWithDataModel<GameViewModel>> getById(int id)
        {
            var result = new ResponseWithDataModel<GameViewModel> { success = true};
            
            var game = new GameViewModel();
            game.Id = id;


            game.Card = (await _gameCardRepository.ByGame(id)).Select(c => new GameCardViewModel
            {
                Image = c.Card.Image,
                ImageDefault = "purple_back.png",
                CardType = c.Card.CardType,
                Id = c.Id,
                IsMatch = c.IsMatch,
                FlippedPlayerId = c.FlippedPlayerId
            }
           ).ToList();

            game.Player = (await _gamePlayerRepository.GetByGameId(id))
                .Select( o => new GamePlayerViewModel { Score = o.Score, 
                    PlayerId = o.PlayerId, 
                    Name = o.Player.Name,
                    GameId = o.GameId,
                    Id = o.Id,
                }).ToList();

            result.Data = game;

            return result;
        }


    }
}
