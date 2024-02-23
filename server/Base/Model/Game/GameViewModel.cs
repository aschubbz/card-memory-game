using Base.Model.Card;
using Base.Model.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Model.Game
{
    public class GameViewModel
    {
        public IList<GameCardViewModel> Card { get; set; }
        public IList<GamePlayerViewModel> Player { get; set; }
    }
}
