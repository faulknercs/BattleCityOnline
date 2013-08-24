using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleCity.GraphicsLib;

namespace BattleCity.GameLib.Tanks
{
    class FastTank : AbstractTank
    {
        public FastTank(Player managingPlayer, int x, int y, Texture.Rotation rotation)
            : base(managingPlayer, x, y, rotation)
        {
            type = Type.PlayerFast;
        }
            
        public override Bullet CreateBullet()
        {
            throw new NotImplementedException();
        }
    }
}
