using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameLib
{
    /// <summary>
    /// Represents an object of game map.
    /// </summary>
    class MapObject
    {
        public enum Types
        {
            EMPTY = 0,
            TANK,
            BRICK,
            CONCRETE,
            WATER,
            FOREST,
            BASE
        }

        public MapObject(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

    }
}
