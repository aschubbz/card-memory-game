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
        bool Update(IList<GameCard> gameCards);
        Task<GameCard> GetById(int id);
        Task<IEnumerable<GameCard>> ByGame(int id);
        Task<IEnumerable<GameCard>> GetById(IList<int> ids);


    }
}
