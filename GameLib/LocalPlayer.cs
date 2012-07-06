using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameLib
{
    /// <summary>
    /// Represents local player, which connected from current proccess
    /// </summary>
    public class LocalPlayer : Player
    {
        public event PlayerKeyEventHandler UpCommand;
        public event PlayerKeyEventHandler DownCommand;
        public event PlayerKeyEventHandler LeftCommand;
        public event PlayerKeyEventHandler RightCommand;
        public event PlayerKeyEventHandler ShootCommand;

    }
}
