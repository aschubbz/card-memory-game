using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    public sealed class CardCategory
    {
        private readonly int _value;
        private CardCategory(int value)
        {
            _value = value;
        }

        public static implicit operator int(CardCategory @enum)
        {
            return @enum._value;
        }

        private static CardCategory? _CLUBS;
        private static CardCategory? _DIAMONDS;
        private static CardCategory? _HEARTS;
        private static CardCategory? _SPADES;
    

        public static CardCategory CLUBS => _CLUBS ?? (_CLUBS = new CardCategory(1));
        public static CardCategory DIAMONDS => _DIAMONDS ?? (_DIAMONDS = new CardCategory(2));
        public static CardCategory HEARTS => _HEARTS ?? (_HEARTS = new CardCategory(3));
        public static CardCategory SPADES => _SPADES ?? (_SPADES = new CardCategory(4));

    }


}
