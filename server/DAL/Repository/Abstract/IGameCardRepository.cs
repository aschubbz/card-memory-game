using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Abstract
{
    public interface IGameCardRepository
    {
        Task<bool> Create(IList<GameCard> gamePlayer);
        Task<IEnumerable<GameCard>> Get();
        GameCard Update(GameCard gameCard);
        Task<GameCard> GetById(int id);
        Task<GameCard> ByGame(int id);


    }
}
