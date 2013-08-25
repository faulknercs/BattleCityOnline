using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using BattleCity.GameLib.Tanks;
using BattleCity.GraphicsLib;

namespace BattleCity.GameLib
{
    public class Level : Map
    {
        public Level(Map map)
        {
            this.map = (new Map(map.MapInstance)).MapInstance;
        }

        public void AddTank(Player player, AbstractTank.Type tankType, int x, int y, Texture.Rotation rotation)
        {
            switch (tankType)
            {
                case AbstractTank.Type.PlayerNormal:
                    tanks.Add(new NormalTank(player, x, y, rotation));
                    break;
                case AbstractTank.Type.PlayerFast:
                    tanks.Add(new FastTank(player, x, y, rotation));
                    break;
            }
        }

        /// <summary>
        /// Gets read-only collection of tanks, which exist on current level
        /// </summary>
        public IList<AbstractTank> Tanks
        {
            get
            {
                return new ReadOnlyCollection<AbstractTank>(tanks);
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
            foreach(AbstractTank tank in tanks)
            {

            }
        }

        public void ProcessBullets()
        {
            foreach(Bullet bullet in bullets)
            {

            }
        }

        private void MoveTankUp(AbstractTank tank)
        {

        }

        private void MoveTankDown(AbstractTank tank)
        {

        }

        private void MoveTankRight(AbstractTank tank)
        {

        }

        private void MoveTankLeft(AbstractTank tank)
        {

        }

        private const int mapBlockSize = 20;
        private IList<Bullet> bullets = new List<Bullet>();
        private IList<AbstractTank> tanks = new List<AbstractTank>();
    }
}
