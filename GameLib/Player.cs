using System;
using System.Collections.Generic;
using System.Text;
using BattleCity.GameLib.Events;
using BattleCity.GameLib.Tanks;

namespace BattleCity.GameLib
{
    /// <summary>
    /// Represents the method, that will handle player's commands events
    /// </summary>
    /// <param name="sender">Source of event</param>
    /// <param name="args">Event arguments, contains information about key state</param>
    public delegate void PlayerKeyEventHandler(Object sender, PlayerKeyEventArgs args);

    /// <summary>
    /// Class, which represents abstract player
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

        public AbstractTank tank;

        public abstract void MessageEventHandler(Object source, MessageEventArgs args);

        protected virtual void OnUpCommand(PlayerKeyEventArgs args)
        {
            if (UpCommand != null)
                UpCommand(this, args);
        }

        protected virtual void OnDownCommand(PlayerKeyEventArgs args)
        {
            if (DownCommand != null)
                DownCommand(this, args);
        }

        protected virtual void OnLeftCommand(PlayerKeyEventArgs args)
        {
            if (LeftCommand != null)
                LeftCommand(this, args);
        }

        protected virtual void OnRightCommand(PlayerKeyEventArgs args)
        {
            if (RightCommand != null)
                RightCommand(this, args);
        }

        protected virtual void OnShootCommand(PlayerKeyEventArgs args)
        {
            if (ShootCommand != null)
                ShootCommand(this, args);
        }
    }
}
