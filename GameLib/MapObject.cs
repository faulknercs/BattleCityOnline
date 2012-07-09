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
            BASE,
            TEMPORARY // Do not use it as type of MapObject. Needs for some actions
        }

        public MapObject(int x, int y, Types type)
        {
            this.X = x;
            this.Y = y;
            this.Type = type;
        }


        public int X { get; set; } //using X insted of x because of in C# adopted PascalCase Code Style

        public int Y { get; set; }

        public Types Type { get; set; }
    }
}