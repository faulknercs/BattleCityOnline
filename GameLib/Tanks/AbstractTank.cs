using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleCity.GameLib.Events;
using BattleCity.GraphicsLib;

namespace BattleCity.GameLib.Tanks
{
    /// <summary>
    /// Class, which represents game tank
    /// </summary>
    public abstract class AbstractTank
    {
        public enum Type 
        {
            PlayerNormal,
            PlayerFast
        }

        public Type type { get; protected set; }

        public Texture.Rotation rotation { get; private set; }

        public AbstractTank(Player managingPlayer, int x, int y, Texture.Rotation rotation)
        {
            this.managingPlayer = managingPlayer;
            X = x;
            Y = y;
            this.rotation = rotation;
            Init();
        }

        public void Rotate(Texture.Rotation rotation)
        {
            if (!this.rotation.Equals(rotation))
            {
                this.rotation = rotation;
            }
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        //public bool IsUpState { get; private set; }

        //public bool IsDownState { get; private set; }

        //public bool IsLeftState { get; private set; }

        //public bool IsRightState { get; private set; }

        public abstract Bullet CreateBullet();

        private void UpCommandHandler(Object source, PlayerKeyEventArgs args)
        {
            Rotate(Texture.Rotation.Top);
            //IsUpState = args.KeyReleased;
        }

        private void DownCommandHandler(Object source, PlayerKeyEventArgs args)
        {
            Rotate(Texture.Rotation.Bottom);
            //IsDownState = args.KeyReleased;
        }

        private void RightCommandHandler(Object source, PlayerKeyEventArgs args)
        {
            Rotate(Texture.Rotation.Right);
            //IsRightState = args.KeyReleased;
        }

        private void LeftCommandHandler(Object source, PlayerKeyEventArgs args)
        {
            Rotate(Texture.Rotation.Left);
            //IsLeftState = args.KeyReleased;
        }

        private void Init()
        {
            managingPlayer.UpCommand += UpCommandHandler;
            managingPlayer.DownCommand += DownCommandHandler;
            managingPlayer.LeftCommand += LeftCommandHandler;
            managingPlayer.RightCommand += RightCommandHandler;

            //IsUpState = false;
            //IsDownState = false;
            //IsLeftState = false;
            //IsRightState = false;
        }

        private Player managingPlayer;
    }
}
