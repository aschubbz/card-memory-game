using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GamePlayer> GamePlayer { get; } = new List<GamePlayer>();
        public ICollection<GameCard> GameCard { get; } = new List<GameCard>();
        
    }
}
