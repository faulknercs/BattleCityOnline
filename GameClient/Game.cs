using System;
using System.Collections.Generic;
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
                    if (TankCanMove(level, player.tank, Texture.Rotation.Top))
                    {
                        player.tank.MoveUp();
                    }
                }
                else if (player.tank.IsDownState)
                {
                    player.tank.Rotate(Texture.Rotation.Bottom);
                    if (TankCanMove(level, player.tank, Texture.Rotation.Bottom))
                    {
                        player.tank.MoveDown();
                    }
                }
                else if (player.tank.IsRightState)
                {
                    player.tank.Rotate(Texture.Rotation.Right);
                    if (TankCanMove(level, player.tank, Texture.Rotation.Right))
                    {
                        player.tank.MoveRight();
                    }
                }
                else if (player.tank.IsLeftState)
                {
                    player.tank.Rotate(Texture.Rotation.Left);
                    if (TankCanMove(level, player.tank, Texture.Rotation.Left))
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
                gameRenderer.DrawMap(level.MapInstance);
                gameRenderer.DrawTanks(level.Tanks);
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

        private bool TankCanMove(Level level, AbstractTank tank, Texture.Rotation rotation)
        {
            PointF pos = TankPositionOnMap(tank);
            List<MapObject.Types> nextMapObjectType = NextMapObjects(level, tank, rotation);
            List<MapObject.Types> currentMapObjectType = CurrentMapObjects(level, tank, rotation);
            nextMapObjectType.RemoveAll(x => x.Equals(MapObject.Types.FOREST) || x.Equals(MapObject.Types.EMPTY));
            currentMapObjectType.RemoveAll(x => x.Equals(MapObject.Types.FOREST) || x.Equals(MapObject.Types.EMPTY));
            return currentMapObjectType.Count.Equals(0);
            //TODO: Maybe tank size reduce in 2 pixels, so we can get real 1 pixel differ in borders of textures
            //if (currentMapObjectType.Count.Equals(0))
            //{
            //    return true;
            //}
            //else
            //{
            //    return nextMapObjectType.Count.Equals(0);
            //}

            //if (!mapObjectType.Exists(x => x.Equals(MapObject.Types.TEMPORARY)))
                ////{
                //    if (mapObjectType.Count.Equals(0))
                //    {
                //        return true;
                //    }
                    //switch (rotation)
                    //{
                    //    case Texture.Rotation.Top:
                    //        return nextMapObjectType.Count.Equals(0);
                    //    case Texture.Rotation.Bottom:
                    //        //if (mapObjectType.Equals(MapObject.Types.FOREST) ||
                    //        //    mapObjectType.Equals(MapObject.Types.EMPTY))
                    //        {
                    //            return true;
                    //        }
                    //        break;
                    //    case Texture.Rotation.Right:
                    //        //if (mapObjectType.Equals(MapObject.Types.FOREST) ||
                    //        //    mapObjectType.Equals(MapObject.Types.EMPTY))
                    //        {
                    //            return true;
                    //        }
                    //        break;
                    //    case Texture.Rotation.Left:
                    //        //if (mapObjectType.Equals(MapObject.Types.FOREST) ||
                    //        //    mapObjectType.Equals(MapObject.Types.EMPTY))
                    //        {
                    //            return true;
                    //        }
                    //        break;
                    //}
                //}
            //}
            //return false;
        }

        private List<MapObject.Types> CurrentMapObjects(Level level, AbstractTank tank, Texture.Rotation rotation)
        {
            PointF tankPositionOnMap = TankPositionOnMap(tank);
            float fX = (float) Math.Round(tankPositionOnMap.X, 0), fY = (float)Math.Round(tankPositionOnMap.Y, 0);
            List<MapObject.Types> objects = new List<MapObject.Types>();

            switch (rotation)
            {
                case Texture.Rotation.Top:
                    objects.Add(level.MapInstance[(int)tankPositionOnMap.Y][(int)tankPositionOnMap.X].Type);
                    if (tank.Y.Equals((int)(windowHeight / 2 - fY * gameRenderer.ElementHeight)))
                    {
                        if (tankPositionOnMap.Y.Equals(0)) return new List<MapObject.Types> { MapObject.Types.TEMPORARY };
                    }
                    else
                    {
                        if (tankPositionOnMap.X - ((int)tankPositionOnMap.X) > 0)
                        {
                            objects.Add(level.MapInstance[(int)tankPositionOnMap.Y][(int)tankPositionOnMap.X + 1].Type);
                        }
                    }
                    break;
                case Texture.Rotation.Bottom:
                    objects.Add(level.MapInstance[(int)tankPositionOnMap.Y][(int)tankPositionOnMap.X].Type);
                    if ((tank.Y-gameRenderer.ElementHeight).Equals((int)(windowHeight / 2 - (fY+1) * gameRenderer.ElementHeight)))
                    {
                        if (tankPositionOnMap.Y.Equals(19)) return new List<MapObject.Types> { MapObject.Types.TEMPORARY };
                    }
                    else
                    {
                        if (tankPositionOnMap.X - ((int)tankPositionOnMap.X) > 0)
                        {
                            objects.Add(level.MapInstance[(int)tankPositionOnMap.Y][(int)tankPositionOnMap.X + 1].Type);
                        }
                    }
                    break;
                    //TODO: Do other stuff
                case Texture.Rotation.Right:
                    if ((tank.X + gameRenderer.ElementWidth).Equals((int)(-windowWidth / 2 + (fX + 1) * gameRenderer.ElementWidth)))
                    {
                        if (Math.Round(tankPositionOnMap.X, 0).Equals(18))
                            return new List<MapObject.Types> {MapObject.Types.TEMPORARY};
                        return new List<MapObject.Types>
                            {
                                level.MapInstance[(int) Math.Round(tankPositionOnMap.Y, 0)][(int) Math.Round(tankPositionOnMap.X, 0) + 1].Type
                            };
                    }
                    break;
                case Texture.Rotation.Left:
                    if (tank.X.Equals((int)(-windowWidth/2 + fX * gameRenderer.ElementWidth)))
                    {
                        if (Math.Round(tankPositionOnMap.X, 0).Equals(0))
                            return new List<MapObject.Types> {MapObject.Types.TEMPORARY};
                        return new List<MapObject.Types>
                            {
                                level.MapInstance[(int) Math.Round(tankPositionOnMap.Y, 0)][(int) Math.Round(tankPositionOnMap.X, 0) - 1].Type
                            };
                    }
                    break;
            }
            return objects;
        }

        private List<MapObject.Types> NextMapObjects(Level level, AbstractTank tank, Texture.Rotation rotation)
        {
            PointF tankPositionOnMap = TankPositionOnMap(tank);
            float fX = (float)Math.Round(tankPositionOnMap.X, 0), fY = (float)Math.Round(tankPositionOnMap.Y, 0);
            List<MapObject.Types> objects = new List<MapObject.Types>();

            switch (rotation)
            {
                case Texture.Rotation.Top:
                    //if (tank.Y.Equals((int)(windowHeight / 2 - fY * gameRenderer.ElementHeight)))
                    //{
                    //    if (tankPositionOnMap.Y.Equals(0)) return new List<MapObject.Types> { MapObject.Types.TEMPORARY };
                    //}
                    //else
                    //{
                    //    objects.Add(level.MapInstance[(int)tankPositionOnMap.Y-1][(int)tankPositionOnMap.X].Type);
                    //    if (tankPositionOnMap.X - ((int)tankPositionOnMap.X) > 0)
                    //    {
                    //        objects.Add(level.MapInstance[(int)tankPositionOnMap.Y-1][(int)tankPositionOnMap.X + 1].Type);
                    //    }
                    //}
                    break;
                case Texture.Rotation.Bottom:
                    break;
                case Texture.Rotation.Right:
                    break;
                case Texture.Rotation.Left:
                    break;
            }
            return objects;
        }
        private PointF TankPositionOnMap(AbstractTank tank)
        {
            return new PointF((tank.X + windowWidth/2)/gameRenderer.ElementWidth,
                              (tank.Y - windowHeight/2)/gameRenderer.ElementHeight * -1);
        }

        MainMenu m;
        private IRendererImpl renderer;
        private Level level;
        private LocalPlayer player;
        private const String windowName = "Battle City Online";

        private GameState activeState = GameState.MAINMENU;
    }
}