using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Model.Card
{
    public class GameCardViewModel
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int GameId { get; set; }
        public int FlipedState { get; set; }
        public int? FlippedPlayerId { get; set; }
        public int? FlippedOrder { get; set; }
        public int Order { get; set; }
        public int IsMatch { get; set; }
        public string? Image { get; set;}
    }
}
