using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCity.GameLib
{
    // TODO: remake this, thinks, we can del class
    public class Map
    {
        public Map()
        {

        }

        public Map(MapObject[][] content)
        {
            map = content;
        }

        public MapObject[][] MapInstance
        {
            get
            {
                return map;
            }
        }

        protected MapObject[][] map;

        private const uint width = 19;
        private const uint height = 20;
    }
}