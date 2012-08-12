using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using BattleCity.GameLib.Tanks;

namespace BattleCity.GameLib
{
    class Level : Map
    {
        public Level(Map map)
        {
            for (int i = 0; i < this.map.Length; ++i )
            {
                for (int j = 0; j < this.map[i].Length; ++j)
                {
                    this.map[i][j] = map.GetInternalForm()[i][j];// TODO: thinks, there is better variant...
                }
            }
        }

        /// <summary>
        /// Gets read-only collection of tanks, which exist on current level
        /// </summary>
        public IList<Tank> Tanks
        {
            get
            {
                return new ReadOnlyCollection<Tank>(tanks);
            }
        }

        /// <summary>
        /// Gets read-only collection of bullets, which exist on current level
        /// </summary>
        public IList<Bullet> Bullets
        {
            get
            {
                return new ReadOnlyCollection<Bullet>(bullets);
            }
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
