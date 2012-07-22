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

        private IList<Bullet> bullets = new List<Bullet>();
        private IList<TankObject> tanks = new List<TankObject>();
    }
}
