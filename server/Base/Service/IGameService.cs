using Base.Model.Card;
using Base.Model.Common;
using Base.Model.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Service
{
    public interface IGameService
    {
        Task<ResponseWithDataModel<GameViewModel>> start();
        Task<CardFlipedResultModel> FlipCard(CardFlipModel model);
        Task<ResponseWithDataModel<GameViewModel>> getById(int id);
        Task<ResponseWithDataModel<bool>> End(int id);
    }
}
