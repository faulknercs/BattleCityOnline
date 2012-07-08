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
        public event PlayerKeyEventHandler UpCommand;
        public event PlayerKeyEventHandler DownCommand;
        public event PlayerKeyEventHandler LeftCommand;
        public event PlayerKeyEventHandler RightCommand;
        public event PlayerKeyEventHandler ShootCommand;

        public void KeyEventHandler(Object source, KeyboardKeyEventArgs args)
        {
            PlayerKeyEventArgs p_args = new PlayerKeyEventArgs(Keyboard.GetState().IsKeyUp(args.Key));
            // TODO: Add other keys
            if (args.Key == Game.Keys.UpKey)
                UpCommand(this, p_args);
        }
    }
}
