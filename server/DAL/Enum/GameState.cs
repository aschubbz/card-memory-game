using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    public sealed class GameState
    {
        private readonly int _value;
        private GameState(int value)
        {
            _value = value;
        }

        public static implicit operator int(GameState @enum)
        {
            return @enum._value;
        }

        private static GameState? _STARTED;
        private static GameState? _COMPLETED;
    

        public static GameState STARTED => _STARTED ?? (_STARTED = new GameState(1));
        public static GameState COMPLETED => _COMPLETED ?? (_COMPLETED = new GameState(2));
    }


}
