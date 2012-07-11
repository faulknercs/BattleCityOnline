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
            windowHeight = Convert.ToInt16(height / ((400 / 380) * 13.5));
            windowWidth = Convert.ToInt16(width / 13.5);
            elementWidth = windowWidth / 19;
            elementHeight = windowHeight / 20;
        }

        private Texture[] textureList;
        private float windowWidth;
        private float windowHeight;
        private float elementWidth;
        private float elementHeight;

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
                map = new Map(MapGenerator.generateCLASSIC_Map());
            if (Keyboard[Key.W])
                map = new Map(MapGenerator.generateDM_Map());
            if (Keyboard[Key.E])
                map = new Map(MapGenerator.generateTDMB_Map());
            if (Keyboard[Key.R])
                map = new Map(MapGenerator.generateTDM_Map());
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

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color.Black);

            watchMapGenerator();

            SwapBuffers();
        }

        private void watchMapGenerator()
        {
            Matrix4 modelview = Matrix4.LookAt(0, 0, 50, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            if (map != null)
                for (int i = 0; i < map.GetInternalForm().Length; i++)
                    for (int j = 0; j < map.GetInternalForm()[i].Length; j++)
                    {
                        double xStart = Convert.ToDouble(j);
                        double yStart = Convert.ToDouble(i);
                        switch (map.GetInternalForm()[i][j].Type)
                        {
                            case MapObject.Types.EMPTY: DrawMapPart(xStart, yStart, 0);
                                break;
                            case MapObject.Types.BRICK: DrawMapPart(xStart, yStart, 1);
                                break;
                            case MapObject.Types.CONCRETE: DrawMapPart(xStart, yStart, 2);
                                break;
                            case MapObject.Types.WATER: DrawMapPart(xStart, yStart, 3);
                                break;
                            case MapObject.Types.FOREST: DrawMapPart(xStart, yStart, 4);
                                break;
                            case MapObject.Types.BASE: DrawMapPart(xStart, yStart, 5);
                                break;
                        }
                    }

            for (int i = 0; i <= 19; i++)
            {
                GL.Begin(BeginMode.Lines);
                GL.Color3(Color.Black);
                GL.LineWidth(1);
                GL.Vertex3(-windowWidth / 2 + i * elementWidth, windowHeight / 2, 0);
                GL.Vertex3(-windowWidth / 2 + i * elementWidth, -windowHeight / 2, 0);
                GL.End();
            }
            for (int i = 0; i <= 20; i++)
            {
                GL.Begin(BeginMode.Lines);
                GL.Color3(Color.Black);
                GL.LineWidth(1);
                GL.Vertex3(-windowWidth / 2, windowHeight / 2 - i * elementHeight, 0);
                GL.Vertex3(windowWidth / 2, windowHeight / 2 - i * elementHeight, 0);
                GL.End();
            }
        }

        private void DrawMapPart(double leftX, double leftY, int textureIndex)
        {
            GL.Begin(BeginMode.Quads);

            textureList[textureIndex].Bind();
            GL.Vertex3(-windowWidth / 2 + leftX * elementWidth, windowHeight / 2 - leftY * elementHeight, 0);
            GL.Vertex3(-windowWidth / 2 + leftX * elementWidth + elementWidth, windowHeight / 2 - leftY * elementHeight, 0);
            GL.Vertex3(-windowWidth / 2 + leftX * elementWidth + elementWidth, windowHeight / 2 - leftY * elementHeight - elementHeight, 0);
            GL.Vertex3(-windowWidth / 2 + leftX * elementWidth, windowHeight / 2 - leftY * elementHeight - elementHeight, 0);

            GL.End();
        }

        private Map map;
        private Player player = new LocalPlayer();
        private const String windowName = "Battle City Online";
    }
}