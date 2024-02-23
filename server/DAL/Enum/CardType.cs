using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    public sealed class CardType
    {
        private readonly int _value;
        private CardType(int value)
        {
            _value = value;
        }

        public static implicit operator int(CardType @enum)
        {
            return @enum._value;
        }


        private static CardType? _TWO;
        private static CardType? _THREE;
        private static CardType? _FOUR;
        private static CardType? _FIVE;
        private static CardType? _SIX;
        private static CardType? _SEVEN;
        private static CardType? _EIGHT;
        private static CardType? _NINE;
        private static CardType? _TEN;
        private static CardType? _JACK;
        private static CardType? _KING;
        private static CardType? _QUEEN;
        private static CardType? _ACE;


        public static CardType TWO => _TWO ?? (_TWO = new CardType(2));
        public static CardType THREE => _THREE ?? (_THREE = new CardType(3));
        public static CardType FOUR => _FOUR ?? (_FOUR = new CardType(4));
        public static CardType FIVE => _FIVE ?? (_FIVE = new CardType(5));

        public static CardType SIX => _SIX ?? (_SIX = new CardType(6));
        public static CardType SEVEN => _SEVEN ?? (_SEVEN = new CardType(7));
        public static CardType EIGHT => _EIGHT ?? (_EIGHT = new CardType(8));
        public static CardType NINE => _NINE ?? (_NINE = new CardType(9));
        public static CardType TEN => _TEN ?? (_TEN = new CardType(10));
        public static CardType JACK => _JACK ?? (_JACK = new CardType(11));
        public static CardType KING => _KING ?? (_KING = new CardType(12));
        public static CardType QUEEN => _QUEEN ?? (_QUEEN = new CardType(13));
        public static CardType ACE => _ACE ?? (_ACE = new CardType(14));
    }


}
