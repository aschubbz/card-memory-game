using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Game
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Sate { get; set; }
        public ICollection<GameCard> GameCard { get; } = new List<GameCard>();
        public ICollection<GamePlayer> GamePlayer { get; } = new List<GamePlayer>();


    }
}
