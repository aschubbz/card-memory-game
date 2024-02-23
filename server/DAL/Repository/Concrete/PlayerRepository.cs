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
    internal class PlayerRepository : IPlayerRepository
    {
        DataContext _context;
        public PlayerRepository(DataContext context)
        {
            _context = context;
        }
        async public Task<IEnumerable<Player>> Get()
        {
            return await _context.player.ToListAsync();
        }

        async public Task<Player> GetById(int id)
        {
            return await _context.player.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
