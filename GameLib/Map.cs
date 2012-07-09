using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameLib
{
    public class Map
    {
        public Map(MapObject[][] content)
        {
            this.map = content;
        }

        public MapObject[][] GetInternalForm()
        {
            // TODO: Maybe, should return clone of map instead of reference (slower, but safer). Or maybe this method isn't needed
            return map;
        }

        public void AddMapObject(MapObject obj, int x, int y)
        {
            this.map[x][y] = obj; // should add x & y check (IndexOutOfBounds).
        }

        private MapObject[][] map;

        private const uint width = 19;
        private const uint height = 20;
    }
}