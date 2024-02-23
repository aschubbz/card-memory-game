using Base.Model.Card;
using Base.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Service
{
    public interface IGameService
    {
        Task<ResponseWithDataModel<IList<CardViewModel>>>start();
        Task<CardFlipedResultModel> FlipCard(CardFlipModel model);
    }
}
