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
                                  new Texture(new Bitmap(Properties.Resources._empty)),
                                  new Texture(new Bitmap(Properties.Resources._brick)),
                                  new Texture(new Bitmap(Properties.Resources._concrete)),
                                  new Texture(new Bitmap(Properties.Resources._water)),
                                  new Texture(new Bitmap(Properties.Resources._forest)),
                                  new Texture(new Bitmap(Properties.Resources._base))
                              };

            WindowBorder = WindowBorder.Fixed;
            windowHeight = Convert.ToInt16(height / ((400 / 380) * 13.5));
            windowWidth = Convert.ToInt16(width / 13.5);
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
            base.OnResize(e);

            GL.Viewport(ClientRectangle);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
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
            base.OnRenderFrame(e);

            Matrix4 modelview = Matrix4.LookAt(0, 0, 50, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            if (needDrawMap)
            {
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                GL.ClearColor(Color.Black);
                gameRenderer.drawMap(map);
                needDrawMap = false;
            }
            if (needRefreshMap)
            {
                /* clear the proper quad and replace it a texture
                GL.Begin(BeginMode.Quads);
                GL.Color3(Color.Black);
                GL.Vertex3(-windowWidth / 2, windowHeight / 2, 0);
                GL.Vertex3(-windowWidth / 2 + windowWidth / 19, windowHeight / 2, 0);
                GL.Vertex3(-windowWidth / 2 + windowWidth / 19, windowHeight / 2 - windowHeight / 19, 0);
                GL.Vertex3(-windowWidth / 2, windowHeight / 2 - windowHeight / 19, 0);
                GL.End();
                gameRenderer.refreshMap(0, 0, MapObject.Types.CONCRETE);
                */
                needRefreshMap = false;
            }

            SwapBuffers();
        }

        private Map map;
        private Player player = new LocalPlayer();
        private const String windowName = "Battle City Online";
    }
}