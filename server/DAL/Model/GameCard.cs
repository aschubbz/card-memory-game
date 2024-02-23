using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class GameCard
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Card Card { get; set; }
        public int CardId { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public int FlipedState { get; set; }
        public int? FlippedPlayerId {  get; set; }
        public Player? FlippedPlayer { get; set; }
        public int? FlippedOrder { get; set; }
        public int Order { get; set; }
        public int IsMatch { get; set; }
    }
}
