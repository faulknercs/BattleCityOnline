using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameLib
{
    class LocalPlayer : IPlayer
    {
        public event PlayerKeyEventHandler UpCommand;
        public event PlayerKeyEventHandler DownCommand;
        public event PlayerKeyEventHandler LeftCommand;
        public event PlayerKeyEventHandler RightCommand;
        public event PlayerKeyEventHandler ShootCommand;

    }
}
