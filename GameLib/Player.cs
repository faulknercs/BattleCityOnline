using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameLib
{
    /// <summary>
    /// Represents the method, that will handle player's commands events
    /// </summary>
    /// <param name="sender">Source of event</param>
    /// <param name="args">Event arguments, contains information about key state</param>
    public delegate void PlayerKeyEventHandler(Object sender, PlayerKeyEventArgs args);

    /// <summary>
    /// Interface, which represents player
    /// </summary>
    public abstract class Player
    {
        public event PlayerKeyEventHandler UpCommand;
        public event PlayerKeyEventHandler DownCommand;
        public event PlayerKeyEventHandler LeftCommand;
        public event PlayerKeyEventHandler RightCommand;
        public event PlayerKeyEventHandler ShootCommand;

        /// <summary>
        /// Holds name of the player
        /// </summary>
        public String Name { get; set; }

        public uint Score { get; set; }
        public uint Lives { get; set; }
    }
}
