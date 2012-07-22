using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameLib
{
    /// <summary>
    /// Represents an object of game map.
    /// </summary>
    public class MapObject
    {
        /// <summary>
        /// Types of the objects, which can exists on game map
        /// </summary>
        public enum Types
        {
            EMPTY = 0,
            TANK,
            BRICK,
            HALF_BRICK_LEFT,
            HALF_BRICK_RIGHT,
            HALF_BRICK_TOP,
            HALF_BRICK_BOTTOM,
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

        /// <summary>
        /// x-coordinate of object
        /// </summary>
        public int X { get; set; } //using X insted of x because of in C# adopted PascalCase Code Style

        /// <summary>
        /// y-coordinate of object
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Type of object
        /// </summary>
        public Types Type { get; set; }
    }
}