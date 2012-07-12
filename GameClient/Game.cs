using System;
using System.Drawing;
using BattleCity.GameClient.GUI;
using BattleCity.GameLib;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace BattleCity.GameClient
{
    /// <summary>
    /// Main class of the game.
    /// </summary>
    internal class Game : GameWindow
    {
        public Game(int width, int height)
            : base(width, height, GraphicsMode.Default, windowName)
        {
            Keyboard.KeyRepeat = false;
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.OneMinusSrcAlpha);

            textureList = new[]
                              {
                                  new Texture(new Bitmap(Properties.Resources.empty)),
                                  new Texture(new Bitmap(Properties.Resources.brick)),
                                  new Texture(new Bitmap(Properties.Resources.concrete)),
                                  new Texture(new Bitmap(Properties.Resources.water)),
                                  new Texture(new Bitmap(Properties.Resources.forest)),
                                  new Texture(new Bitmap(Properties.Resources._base))
                              };

            WindowBorder = WindowBorder.Fixed;
            windowWidth = width;
            windowHeight = height;
            gameRenderer = new GameRenderer(windowWidth, windowHeight, textureList);
        }

        private GameRenderer gameRenderer;
        private Texture[] textureList;
        private float windowWidth;
        private float windowHeight;
        private bool needDrawMap, needRefreshMap;

        /// <summary>
        /// Load resources before main loop
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        /// <summary>
        /// Called when your window is resized. Set your viewport here. It is also
        /// a good place to set up your projection matrix (which probably changes
        /// along when the aspect ratio of your window).
        /// </summary>
        /// <param name="e">Not used.</param>
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, (int)windowWidth, (int)windowHeight);

            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 ortho = Matrix4.CreateOrthographicOffCenter(-windowWidth / 2, windowWidth / 2, -windowHeight / 2, windowHeight / 2, 1, -1);
            GL.LoadMatrix(ref ortho);

            GL.MatrixMode(MatrixMode.Modelview);

            base.OnResize(e);
        }

        /// <summary>
        /// Called when it is time to setup the next frame.
        /// </summary>
        /// <param name="e">Contains timing information for framerate independent logic.</param>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            //GameLogic gameplay = new GameLogic();
            //gameplay.AddPlayer(player);

            if (Keyboard[Key.Q])
            {
                map = new Map(MapGenerator.generateCLASSIC_Map());
                needDrawMap = true;
            }
            if (Keyboard[Key.W])
            {
                map = new Map(MapGenerator.generateDM_Map());
                needDrawMap = true;
            }
            if (Keyboard[Key.E])
            {
                map = new Map(MapGenerator.generateTDMB_Map());
                needDrawMap = true;
            }
            if (Keyboard[Key.R])
            {
                map = new Map(MapGenerator.generateTDM_Map());
                needDrawMap = true;
            }
            if (Keyboard[Key.Space])
                needRefreshMap = true;

            if (Keyboard[Key.Escape])
                Exit();
        }

        /// <summary>
        /// Called when it is time to render the next frame.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            if (needDrawMap)
            {
                gameRenderer.drawMap(map);
                needDrawMap = false;
            }
            if (needRefreshMap)
            {
                gameRenderer.drawMap(0, 1, MapObject.Types.WATER);
                needRefreshMap = false;
            }

            SwapBuffers();
        }

        private Map map;
        private Player player = new LocalPlayer();
        private const String windowName = "Battle City Online";
    }
}