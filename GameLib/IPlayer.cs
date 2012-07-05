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
    delegate void PlayerKeyEventHandler(Object sender, PlayerKeyEventArgs args);

    /// <summary>
    /// Interface, which represents player
    /// </summary>
    public interface IPlayer
    {
        event PlayerKeyEventHandler UpCommand;
        event PlayerKeyEventHandler DownCommand;
        event PlayerKeyEventHandler LeftCommand;
        event PlayerKeyEventHandler RightCommand;
        event PlayerKeyEventHandler ShootCommand;

        /// <summary>
        /// Holds name of the player
        /// </summary>
        String Name { get; set; }

        uint Score { get; set; }
        uint Lives { get; set; }
    }
}
