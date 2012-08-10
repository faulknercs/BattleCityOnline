using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleCity.GameLib.Tanks;

namespace BattleCity.GameLib
{
    class Level : Map
    {
        public Level(Map map)
            : base(map.GetInternalForm())
        {

        }

        public IList<Tank> GetTanks()
        {
            return tanks;
        }

        public void ProcessTanks()
        {
            foreach(Tank tank in tanks)
            {

            }
        }

        public void ProcessBullets()
        {
            foreach(Bullet bullet in bullets)
            {

            }
        }

        private void MoveTankUp(Tank tank)
        {

        }

        private void MoveTankDown(Tank tank)
        {

        }

        private void MoveTankRight(Tank tank)
        {

        }

        private void MoveTankLeft(Tank tank)
        {

        }

        private const int mapBlockSize = 20;
        private IList<Bullet> bullets = new List<Bullet>();
        private IList<Tank> tanks = new List<Tank>();
    }
}
