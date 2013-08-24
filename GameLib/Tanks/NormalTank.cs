using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameLib.Tanks
{
    public class NormalTank : AbstractTank
    {
        public NormalTank(Player managingPlayer, int x, int y)
            : base(managingPlayer, x, y)
        {
            type = Type.PlayerNormal;
        }

        public override Bullet CreateBullet()
        {
            throw new NotImplementedException();
        }
    }
}
