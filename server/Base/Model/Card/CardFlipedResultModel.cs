using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Model.Card
{
    public class CardFlipedResultModel
    {
        public CardViewModel Card { get; set; }
        
        public bool IsMatch { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public bool IsHaveAnotherChance { get; set; }
    }
}
