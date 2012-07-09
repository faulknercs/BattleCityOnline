using System;
using System.Collections.Generic;
using System.Text;

using BattleCity.GameLib;
using OpenTK.Input;

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

        public void KeyEventHandler(Object source, KeyboardKeyEventArgs args)
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

        private KeySettings keys;
    }
}
