using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleCity.GraphicsLib;

namespace BattleCity.GameLib.Tanks
{
    public class NormalTank : AbstractTank
    {
        public NormalTank(Player managingPlayer, int x, int y, Texture.Rotation rotation)
            : base(managingPlayer, x, y, rotation)
        {
            type = Type.PlayerNormal;
            Speed = 1;
        }

        public override Bullet CreateBullet()
        {
            throw new NotImplementedException();
        }
    }
}
