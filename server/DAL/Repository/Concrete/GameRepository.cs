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
    internal class GameRepository : IGameRepository
    {
        DataContext _context;
        public GameRepository(DataContext context)
        {
            _context = context;
        }
        async public Task<Game>Create(Game game)
        {
            await _context.game.AddAsync(game);
            _context.SaveChanges();
            return game;
        }

        async public Task<Game> Update(Game game)
        {
            throw new NotImplementedException();
        }

        async public Task<Game> Delete(Game game)
        {
            throw new NotImplementedException();
        }

        async public Task<Game> GetById(int id)
        {
           return await _context.game.Include(x => x.GameCard).Include(x => x.GamePlayer).Where(o => o.Id == id).SingleOrDefaultAsync();
        }
    }
}
