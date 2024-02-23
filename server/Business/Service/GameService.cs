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

           var _cards = (await _gameCardRepository.ByGame(game.Id)).Select(c => new GameCardViewModel { Image = "purple_back.png", Id=c.Id}).ToList();


            var game_view_model = new GameViewModel { Card = _cards, Player = _players };
            return new ResponseWithDataModel<GameViewModel>() { Data = game_view_model, success=true, Message= "New game has created" };
        }

        async public Task<CardFlipedResultModel> FlipCard(CardFlipModel model)
        {
            // get game card
            var game_card = await _gameCardRepository.GetById(model.gameCardId);
            
            var result = new CardFlipedResultModel { Success = true};

            // validate if player can flip the card
            if (game_card == null || game_card.FlippedPlayerId != null)
            {
                // return error this card is alrey flliped or game is not available for this card
                result.Success = false;
                result.Message = "This card is alredy flliped Or Invalid input";
                return result;

            }

            // validate players

            var game = await _gameRepository.GetById(game_card.GameId);


            // check if palyer is in
            var player = await this._playerRepository.GetById(model.playerId);
            if (player == null) {
                result.Success = false;
                result.Message = "Player not found";
                return result;
            }



            var last_flip = game.GameCard.OrderByDescending(o => o.FlippedOrder).Where(x=>x.FlippedPlayerId != null).FirstOrDefault();


            var card_payed_by_player = game.GameCard.OrderByDescending(o => o.FlippedOrder).Where(o => o.FlippedPlayerId == model.playerId);

            if (last_flip != null)
            {
                last_flip = await _gameCardRepository.GetById(last_flip.Id);
            }

            if (last_flip  == null || last_flip.FlippedPlayerId == null)
            {
                /* This is new Game just started now */
                game_card.FlippedPlayerId = model.playerId;
                game_card.IsMatch = Matched.BETWEEN_FLIPS;
                game_card.FlippedOrder = 1;
                result.IsHaveAnotherChance = true;
            } else if (last_flip != null
                && (card_payed_by_player.Count() == 0) 
                && last_flip.FlippedPlayerId != model.playerId 
                && last_flip.IsMatch == Matched.NOT_MATCHED
                ) {
                /* This is frist time this playr is playing*/
                game_card.FlippedPlayerId = model.playerId;
                game_card.IsMatch = Matched.BETWEEN_FLIPS;
                game_card.FlippedOrder = last_flip.FlippedOrder + 1;
                result.IsHaveAnotherChance = true;
            }


            // the player had played once this is his second chance
            else if (last_flip.FlippedPlayerId == model.playerId && last_flip.IsMatch == Matched.BETWEEN_FLIPS)
            {
                game_card.FlippedPlayerId = model.playerId;
                game_card.IsMatch = last_flip.Card.CardType == game_card.Card.CardType ? Matched.MATCHED : Matched.NOT_MATCHED;
                result.IsHaveAnotherChance = last_flip.Card.CardType == game_card.Card.CardType;
                game_card.FlippedOrder = last_flip.FlippedOrder + 1;
            }
            // this is his exra chance
            else if (last_flip.FlippedPlayerId == model.playerId && last_flip.IsMatch == Matched.MATCHED)
            {
                game_card.FlippedPlayerId = model.playerId;
                game_card.IsMatch = Matched.BETWEEN_FLIPS;
                result.IsHaveAnotherChance = true;
                game_card.FlippedOrder = last_flip.FlippedOrder + 1;
            }

            // this is this player frist round in this flip
            else if (last_flip.FlippedPlayerId != model.playerId && last_flip.IsMatch == Matched.NOT_MATCHED) 
            {
                game_card.FlippedPlayerId = model.playerId;
                game_card.IsMatch = Matched.BETWEEN_FLIPS;
                result.IsHaveAnotherChance = true;
                game_card.FlippedOrder = last_flip.FlippedOrder + 1;
            }

            // invalid attemp
            else
            {
                result.Success = false;
                result.Message = "Invalid attempt";
                return result;
            }

            var game_card_updated = _gameCardRepository.Update(game_card);


            //result.Card = Mapper.Map<CardViewModel>(game_card_updated.Card);
            // return flipped card result

            var gamePlayer = await _gamePlayerRepository.GetByGameAndPlayerId(game.Id, model.playerId);

            // update player score
            if ( game_card.IsMatch == Matched.MATCHED)
            {
                gamePlayer.Score = gamePlayer.Score + 1;
                _gamePlayerRepository.Update(gamePlayer);
            }
            
            result.Card = new CardViewModel
            {
                Id = game_card_updated.Card.Id,
                CardType = game_card_updated.Card.CardType,
                Name = game_card_updated.Card.Name,
                Image = game_card_updated.Card.Image,
                CardCategory = game_card_updated.Card.Id
            };

            result.Score = gamePlayer.Score;
            result.IsMatch = game_card.IsMatch == Matched.MATCHED;

            return result;
        }
    }
}
