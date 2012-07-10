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
            map = content;
        }

        public MapObject[][] GetInternalForm()
        {
            return map;
        }

        private MapObject[][] map;

        private const uint width = 19;
        private const uint height = 20;
    }
}