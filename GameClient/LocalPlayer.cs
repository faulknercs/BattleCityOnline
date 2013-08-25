using System;
using System.Collections.Generic;
using System.Text;

using BattleCity.GameLib;
using OpenTK.Input;
using BattleCity.GameLib.Events;

namespace BattleCity.GameClient
{
    /// <summary>
    /// Represents local player, which connected from current proccess
    /// </summary>
    public class LocalPlayer : Player
    {
        public LocalPlayer()
        {
            keys.UpKey = Properties.Settings.Default.UpKey;
            keys.DownKey = Properties.Settings.Default.DownKey;
            keys.LeftKey = Properties.Settings.Default.LeftKey;
            keys.RightKey = Properties.Settings.Default.RightKey;
            keys.ShootKey = Properties.Settings.Default.ShootKey;
        }

        /// <summary>
        /// Method, which processes keyboards events (key up and key down).
        /// </summary>
        /// <param name="source">Source of event. Not used.</param>
        /// <param name="args">Arguments of event. Uses to determine, is key up or down</param>
        public void KeyDownEventHandler(Object source, KeyboardKeyEventArgs args)
        {
            PlayerKeyEventArgs p_args = new PlayerKeyEventArgs(Keyboard.GetState().IsKeyUp(args.Key));
            if (args.Key == keys.UpKey)
                OnUpCommand(p_args);
            if (args.Key == keys.DownKey)
                OnDownCommand(p_args);
            if (args.Key == keys.LeftKey)
                OnLeftCommand(p_args);
            if (args.Key == keys.RightKey)
                OnRightCommand(p_args);
            if (args.Key == keys.ShootKey)
                OnShootCommand(p_args);
        }

        public void KeyUpEventHandler(Object source, KeyboardKeyEventArgs args)
        {
            PlayerKeyEventArgs p_args = new PlayerKeyEventArgs(Keyboard.GetState().IsKeyDown(args.Key));
            if (args.Key == keys.UpKey)
                OnUpCommand(p_args);
            if (args.Key == keys.DownKey)
                OnDownCommand(p_args);
            if (args.Key == keys.LeftKey)
                OnLeftCommand(p_args);
            if (args.Key == keys.RightKey)
                OnRightCommand(p_args);
            if (args.Key == keys.ShootKey)
                OnShootCommand(p_args);
        }

        public override void MessageEventHandler(Object source, MessageEventArgs args)
        {
            throw new NotImplementedException();
        }

        private KeySettings keys;
    }
}
