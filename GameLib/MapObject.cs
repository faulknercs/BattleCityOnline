using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameLib
{
    public class MapObject
    {
        public enum Types
        {
            EMPTY = 0,
            TANK,
            BRICK,
            CONCRETE,
            WATER,
            FOREST
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