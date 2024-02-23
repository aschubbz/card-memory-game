using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Abstract
{
    public interface IGamePlayerRepository
    {
        Task<bool> Create(IList<GamePlayer> gamePlayer);
        Task<IEnumerable<GamePlayer>> Get();
        bool Update(GamePlayer gamePlayer);
        Task<GamePlayer> GetByGameAndPlayerId(int gameId, int playerId);
        Task<IEnumerable<GamePlayer>> GetByGameId(int id);
    }
}
