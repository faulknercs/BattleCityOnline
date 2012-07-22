using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameLib
{
    class Level : Map
    {
        public Level(Map map)
            : base(map.GetInternalForm())
        {

        }

        public IList<TankObject> GetTanks()
        {
            return tanks;
        }

        private IList<TankObject> tanks = new List<TankObject>();
    }
}
