using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Card
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CardType {  get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public int CardCategory { get; set; }
        public ICollection<GameCard> GameCard { get; } = new List<GameCard>();

    }
}
