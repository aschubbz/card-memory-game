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
    internal class GameCardRepository : IGameCardRepository
    {
        DataContext _context;
        public GameCardRepository(DataContext context)
        {
            _context = context;
        }
        async public Task<bool> Create(IList<GameCard> gameCards)
        {
            await _context.gameCard.AddRangeAsync(gameCards);
            _context.SaveChanges();
            return true;
        }

        async public Task<IEnumerable<GameCard>> Get()
        {
            return await _context.gameCard.ToListAsync();
        }

        async public Task<GameCard> GetById(int id)
        {
            return await _context.gameCard.Include(x => x.Card).Where(r => r.Id == id).SingleOrDefaultAsync();
        }

        public GameCard Update(GameCard gameCard)
        {
            var result = _context.gameCard.Update(gameCard);
            _context.SaveChanges();
            return result.Entity;
        }

        async public Task<IEnumerable<GameCard>> ByGame(int id)
        {
            return await _context.gameCard.Include(x => x.Card).Where(o => o.GameId == id).ToListAsync();
        }
    }
}
