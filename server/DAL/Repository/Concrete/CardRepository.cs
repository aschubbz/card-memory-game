using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository.Abstract;
using DAL.Model;
using DAL.Module;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Concrete
{
    internal class CardRepository : ICardRepository
    {
        DataContext _context;
        public CardRepository(DataContext context)
        {
            _context = context;
        }

        async public Task<Card> GetById(int id)
        {
            return await _context.cards.Where(o => o.Id == id).FirstOrDefaultAsync();
        }

        async public Task<IEnumerable<Card>> GetRandomCards(int number)
        {
            return await _context.cards.OrderBy(r => EF.Functions.Random()).Take(number).ToListAsync();
        }
    }
}
