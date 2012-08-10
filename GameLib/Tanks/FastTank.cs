using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameLib.Tanks
{
    class FastTank : Tank
    {
        public FastTank(Player managingPlayer, int x, int y)
            : base(managingPlayer, x, y)
        {

        }
            
        public override Bullet CreateBullet()
        {
            throw new NotImplementedException();
        }
    }
}
