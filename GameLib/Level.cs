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

        public IList<TankObject> GetTanks()
        {
            return tanks;
        }

        public void ProcessTanks()
        {
            foreach(TankObject tank in tanks)
            {

            }
        }

        public void ProcessBullets()
        {
            foreach(Bullet bullet in bullets)
            {

            }
        }

        private void MoveTankUp(TankObject tank)
        {

        }

        private void MoveTankDown(TankObject tank)
        {

        }

        private void MoveTankRight(TankObject tank)
        {

        }

        private void MoveTankLeft(TankObject tank)
        {

        }

        private IList<Bullet> bullets = new List<Bullet>();
        private IList<TankObject> tanks = new List<TankObject>();
    }
}
