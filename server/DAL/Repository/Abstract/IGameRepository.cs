using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Abstract
{
    public interface IGameRepository
    {
        Task<Game> Create(Game game);
        Task<Game> Update(Game game);
        Task<Game> Delete(Game game);
        Task<Game> GetById(int id);
    }
}
