using System;
using System.Drawing;
using BattleCity.GameClient.GUI;
using BattleCity.GameLib;
using BattleCity.GameLib.Tanks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using BattleCity.GraphicsLib;
using BattleCity.GameLib.Generators;

namespace BattleCity.GameClient
{
    /// <summary>
    /// Main class of the game.
    /// </summary>
    internal class Game : GameWindow
    {
        public Game(int width, int height)
            : base(width, height, GraphicsMode.Default, windowName, GameWindowFlags.Default, DisplayDevice.Default, 2, 1, GraphicsContextFlags.Default)
        {
            renderer = RendererFactory.Instance.CreateRenderer();
            Keyboard.KeyRepeat = false;
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.OneMinusSrcAlpha);
            
            m = new MainMenu(windowWidth, windowHeight);
            Keyboard.KeyDown += OnMenuControl;

            mapTextureList = new[]
                {
                    new Texture(new Bitmap(GraphicsLib.Properties.Resources.empty)),
                    new Texture(new Bitmap(GraphicsLib.Properties.Resources.brick)),
                    new Texture(new Bitmap(GraphicsLib.Properties.Resources.concrete)),
                    new Texture(new Bitmap(GraphicsLib.Properties.Resources.water)),
                    new Texture(new Bitmap(GraphicsLib.Properties.Resources.forest)),
                    new Texture(new Bitmap(GraphicsLib.Properties.Resources._base))
                };

            tankTextureList = new[]
                {
                    new Texture(new Bitmap(GraphicsLib.Properties.Resources.tankPlayerNormal))
                };

            WindowBorder = WindowBorder.Fixed;
            windowWidth = width;
            windowHeight = height;
            gameRenderer = new GameRenderer(windowWidth, windowHeight, mapTextureList, tankTextureList);
        }

        private GameRenderer gameRenderer;
        private Texture[] mapTextureList;
        private Texture[] tankTextureList;
        private float windowWidth;
        private float windowHeight;

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

            if (activeState.Equals(GameState.SINGLEPL))
            {
                if (Keyboard[Key.Q])
                {
                    level = new Level(new Map(MapGenerator.GenerateMap(GameMode.Mode.CLASSIC)));
                    level.AddTank(player, AbstractTank.Type.PlayerFast, (int)(-windowWidth / 2 + gameRenderer.ElementWidth * 7), (int)(windowHeight / 2 - 19 * gameRenderer.ElementHeight), Texture.Rotation.Top);
                }
                if (Keyboard[Key.W])
                {
                    level = new Level(new Map(MapGenerator.GenerateMap(GameMode.Mode.DM)));
                    //level.AddTank(player, AbstractTank.Type.PlayerNormal, (int)(-windowWidth / 2 + gameRenderer.ElementWidth * 7), (int)(windowHeight / 2 - 19 * gameRenderer.ElementHeight));
                }
                if (Keyboard[Key.E])
                {
                    level = new Level(new Map(MapGenerator.GenerateMap(GameMode.Mode.TDMB)));
                    //level.AddTank(player, AbstractTank.Type.PlayerNormal, (int)(-windowWidth / 2 + gameRenderer.ElementWidth * 7), (int)(windowHeight / 2 - 19 * gameRenderer.ElementHeight));
                }
                if (Keyboard[Key.R])
                {
                    level = new Level(new Map(MapGenerator.GenerateMap(GameMode.Mode.TDM)));
                    //level.AddTank(player, AbstractTank.Type.PlayerNormal, (int)(-windowWidth / 2 + gameRenderer.ElementWidth * 7), (int)(windowHeight / 2 - 19 * gameRenderer.ElementHeight));
                }
                if (Keyboard[Key.Space])
                {
                }
                if (player.tank.IsUpState)
                {
                    player.tank.Rotate(Texture.Rotation.Top);
                    if (gameRenderer.TankCanMove(level, player.tank, Texture.Rotation.Top))
                    {
                        player.tank.MoveUp();
                    }
                }
                else if (player.tank.IsDownState)
                {
                    player.tank.Rotate(Texture.Rotation.Bottom);
                    if (gameRenderer.TankCanMove(level, player.tank, Texture.Rotation.Bottom))
                    {
                        player.tank.MoveDown();
                    }
                }
                else if (player.tank.IsRightState)
                {
                    player.tank.Rotate(Texture.Rotation.Right);
                    if (gameRenderer.TankCanMove(level, player.tank, Texture.Rotation.Right))
                    {
                        player.tank.MoveRight();
                    }
                }
                else if (player.tank.IsLeftState)
                {
                    player.tank.Rotate(Texture.Rotation.Left);
                    if (gameRenderer.TankCanMove(level, player.tank, Texture.Rotation.Left))
                    {
                        player.tank.MoveLeft();
                    }
                }
            }
        }

        /// <summary>
        /// Called when it is time to render the next frame.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            if (activeState.Equals(GameState.MAINMENU))
            {
                renderer.SetColor(Color.White);
                m.Render();
            }
            if (level != null)
            {
                gameRenderer.RenderLevel(level);
            }

            SwapBuffers();
        }

        private void OnMenuControl(object source, KeyboardKeyEventArgs args)
        {
            if (activeState.Equals(GameState.MAINMENU))
            {
                switch (activeState = m.GetStateByKey(args))
                {
                    case GameState.SINGLEPL:
                        player = new LocalPlayer();
                        level = new Level(new Map(MapGenerator.GenerateMap(GameMode.Mode.CLASSIC)));
                        level.AddTank(player, AbstractTank.Type.PlayerNormal, (int)(-windowWidth / 2 + gameRenderer.ElementWidth * 7), (int)(windowHeight / 2 - 19 * gameRenderer.ElementHeight), Texture.Rotation.Top);
                        Keyboard.KeyUp += player.KeyUpEventHandler;
                        Keyboard.KeyDown += player.KeyDownEventHandler;
                        break;
                    case GameState.EXIT:
                        Exit();
                        break;
                }
            }
        }

        

        MainMenu m;
        private IRendererImpl renderer;
        private Level level;
        private LocalPlayer player;
        private const String windowName = "Battle City Online";

        private GameState activeState = GameState.MAINMENU;
    }
}