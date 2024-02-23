using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    public sealed class Matched
    {
        private readonly int _value;
        private Matched(int value)
        {
            _value = value;
        }

        public static implicit operator int(Matched @enum)
        {
            return @enum._value;
        }

        private static Matched? _MATCHED;
        private static Matched? _NOT_MATCHED;
        private static Matched? _BETWEEN_FLIPS;


        public static Matched MATCHED => _MATCHED ?? (_MATCHED = new Matched(1));
        public static Matched NOT_MATCHED => _NOT_MATCHED ?? (_NOT_MATCHED = new Matched(2));
        public static Matched BETWEEN_FLIPS => _BETWEEN_FLIPS ?? (_BETWEEN_FLIPS = new Matched(3));

    }
}
