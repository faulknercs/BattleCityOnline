using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using BattleCity.GameLib;

namespace BattleCity.GameClient
{
    /// <summary>
    /// Main class of the game.
    /// </summary>
    class Game : GameWindow
    {
        public Game(int width, int height)
            : base(width, height, GraphicsMode.Default, windowName)
        {
            Keyboard.KeyRepeat = false;
        }

        /// <summary>
        /// Load resources before main loop
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
        }

        /// <summary>
        /// Called when it is time to setup the next frame.
        /// </summary>
        /// <param name="e">Contains timing information for framerate independent logic.</param>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            GameLogic gameplay = new GameLogic();
            gameplay.AddPlayer(player);

        }

        /// <summary>
        /// Called when it is time to render the next frame.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
        }

        private Player player = new LocalPlayer();
        private const String windowName = "Battle City Online";
    }
}
