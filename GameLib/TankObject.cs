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
        public TankObject(Player managingPlayer, int x, int y)
            : base (x, y)
        {
            this.managingPlayer = managingPlayer;
            Init();
        }

        public bool IsUpState { get; private set; }

        public bool IsDownState { get; private set; }

        public bool IsLeftState { get; private set; }

        public bool IsRightState { get; private set; }

        private void UpCommandHandler(Object source, PlayerKeyEventArgs args)
        {
            IsUpState = args.KeyReleased;
        }

        private void DownCommandHandler(Object source, PlayerKeyEventArgs args)
        {
            IsDownState = args.KeyReleased;
        }

        private void RightCommandHandler(Object source, PlayerKeyEventArgs args)
        {
            IsRightState = args.KeyReleased;
        }

        private void LeftCommandHandler(Object source, PlayerKeyEventArgs args)
        {
            IsLeftState = args.KeyReleased;
        }

        private void Init()
        {
            managingPlayer.UpCommand += new PlayerKeyEventHandler(UpCommandHandler);
            managingPlayer.DownCommand += new PlayerKeyEventHandler(DownCommandHandler);
            managingPlayer.LeftCommand += new PlayerKeyEventHandler(LeftCommandHandler);
            managingPlayer.RightCommand += new PlayerKeyEventHandler(RightCommandHandler);

            IsUpState = false;
            IsDownState = false;
            IsLeftState = false;
            IsRightState = false;
        }

        private Player managingPlayer;
    }
}
