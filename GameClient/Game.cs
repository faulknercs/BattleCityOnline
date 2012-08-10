using System;
using System.Drawing;
using BattleCity.GameClient.GUI;
using BattleCity.GameLib;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using BattleCity.GraphicsLib;
using BattleCity.GameLib.Generator;

namespace BattleCity.GameClient
{
    /// <summary>
    /// Main class of the game.
    /// </summary>
    internal class Game : GameWindow
    {
        public Game(int width, int height)
            : base(width, height, GraphicsMode.Default, windowName, GameWindowFlags.Default, DisplayDevice.Default, 4, 1, GraphicsContextFlags.Default)
        {
            renderer = RendererFactory.Instance.CreateRenderer();
            Keyboard.KeyRepeat = false;
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.OneMinusSrcAlpha);
            m = new MainMenu(windowWidth, windowHeight);
            Keyboard.KeyDown += new EventHandler<KeyboardKeyEventArgs>(MenuControl);
            
            m = new MainMenu(windowWidth, windowHeight);           
            textureList = new[]
                              {
                                  new Texture(new Bitmap(GraphicsLib.Properties.Resources.empty)),
                                  new Texture(new Bitmap(GraphicsLib.Properties.Resources.brick)),
                                  new Texture(new Bitmap(GraphicsLib.Properties.Resources.concrete)),
                                  new Texture(new Bitmap(GraphicsLib.Properties.Resources.water)),
                                  new Texture(new Bitmap(GraphicsLib.Properties.Resources.forest)),
                                  new Texture(new Bitmap(GraphicsLib.Properties.Resources._base))
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
            renderer.Resize(ClientRectangle.Width, ClientRectangle.Height);
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
                map = new Map(MapGenerator.generateMap(new GameMode(GameMode.Mode.CLASSIC)));
                needDrawMap = true;
            }
            if (Keyboard[Key.W])
            {
                map = new Map(MapGenerator.generateMap(new GameMode(GameMode.Mode.DM)));
                needDrawMap = true;
            }
            if (Keyboard[Key.E])
            {
                map = new Map(MapGenerator.generateMap(new GameMode(GameMode.Mode.TDMB)));
                needDrawMap = true;
            }
            if (Keyboard[Key.R])
            {
                map = new Map(MapGenerator.generateMap(new GameMode(GameMode.Mode.TDM)));
                needDrawMap = true;
            }
            if (Keyboard[Key.Space])
                needRefreshMap = true;
        }

        /// <summary>
        /// Called when it is time to render the next frame.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            renderer.SetColor(Color.White);
            m.Render();
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

        private void MenuControl(Object source, KeyboardKeyEventArgs args)
        {
            if (m.GetStateByKey(args) == GameState.EXIT)
                Exit();
        }

        MainMenu m;
        private IRendererImpl renderer;
        private Map map;
        private Player player = new LocalPlayer();
        private const String windowName = "Battle City Online";
    }
}