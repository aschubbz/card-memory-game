using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Abstract
{
    public interface IPlayerRepository
    {
        Task<Player> GetById(int id);
        Task<IEnumerable<Player>> Get();
    }
}
