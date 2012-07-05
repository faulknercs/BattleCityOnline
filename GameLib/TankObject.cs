using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameLib
{
    /// <summary>
    /// Class, which represents game tank
    /// </summary>
    class TankObject : MapObject
    {
        public TankObject(IPlayer managingPlayer, int x, int y)
            : base (x, y)
        {
            this.managingPlayer = managingPlayer;
            managingPlayer.UpCommand += new PlayerKeyEventHandler(UpCommandHandler); // TODO: handlers for other events
        }

        private void UpCommandHandler(Object source, PlayerKeyEventArgs args)
        {

        }

        private IPlayer managingPlayer = null;
    }
}
