using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Repository.Abstract
{
    public interface ICardRepository
    {
        /// <summary>
        /// Get given number random amout of card 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        Task<IEnumerable<Card>> GetRandomCards(int number);

        Task<Card> GetById(int id);

    }
}
