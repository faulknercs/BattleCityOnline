using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameLib
{
    /// <summary>
    /// Represents an object of game map.
    /// </summary>
    internal class MapObject
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
            this.x = x;
            this.y = y;
        }

        public int x { get; set; }

        public int y { get; set; }
    }
}