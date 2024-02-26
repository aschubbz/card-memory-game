using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    public sealed class FlipState
    {
        private readonly int _value;
        private FlipState(int value)
        {
            _value = value;
        }

        public static implicit operator int(FlipState @enum)
        {
            return @enum._value;
        }

        private static FlipState? _MATCHED;
        private static FlipState? _NOT_FLIPED;
    
        public static FlipState MATCHED => _MATCHED ?? (_MATCHED = new FlipState(1));
        public static FlipState NOT_FLIPED => _NOT_FLIPED ?? (_NOT_FLIPED = new FlipState(2));

    }


}
