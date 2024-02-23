using DAL.Model;
using DAL.Module;
using DAL.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Concrete
{
    internal class GamePlayerRepository : IGamePlayerRepository
    {
        DataContext _context;
        public GamePlayerRepository(DataContext context)
        {
            _context = context;
        }
        async public Task<bool> Create(IList<GamePlayer> gamePlayers)
        {
            
            await _context.gamePlayer.AddRangeAsync(gamePlayers);
            _context.SaveChanges();

            return true;
        }

        async public Task<IEnumerable<GamePlayer>> Get()
        {
            return await _context.gamePlayer.ToListAsync();
        }


        public bool Update(GamePlayer gamePlayer)
        {
            _context.gamePlayer.Update(gamePlayer);
            return true;
        }

        async public Task<GamePlayer> GetByGameAndPlayerId(int gameId, int playerId)
        {
            return await _context.gamePlayer.Where(o => o.PlayerId == playerId && o.GameId == gameId).SingleOrDefaultAsync();
        }

        async public Task<IEnumerable<GamePlayer>> GetByGameId(int id)
        {
            return await _context.gamePlayer.Include(x => x.Player).Where(o => o.GameId == id).ToListAsync();
        }
    }
}
