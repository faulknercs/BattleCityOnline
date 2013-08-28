using System;
using System.Collections.Generic;
using System.Drawing;
using BattleCity.GameClient.GUI;
using BattleCity.GameLib;
using BattleCity.GameLib.Tanks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using BattleCity.GraphicsLib;

namespace BattleCity.GameClient
{
    /// <summary>
    /// Class, which is responsible for displaying the gameplay
    /// </summary>
    internal class GameRenderer
    {//think, we can load textures in Renderer instead of passing them as parameter
        public GameRenderer(float windowWidth, float windowHeight, Texture[] mapTextureList, Texture[] tankTextureList)
        {
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
            this.mapTextureList = mapTextureList;
            this.tankTextureList = tankTextureList;
            elementWidth = windowWidth / 19;
            elementHeight = windowHeight / 20;
        }

        public float WindowWidth 
        {
            get { return windowWidth; }
        }

        public float WindowHeight
        {
            get { return windowHeight; }
        }

        public float ElementWidth
        {
            get { return elementWidth; }
        }

        public float ElementHeight
        {
            get { return elementHeight; }
        }

        private float windowWidth, windowHeight;
        private float elementWidth, elementHeight;
        private Texture[] mapTextureList;
        private Texture[] tankTextureList;

        private void DrawTexture(int x, int y, Texture texture, Texture.Rotation rotation)
        {
            Vector2 v1 = new Vector2(), v2 = new Vector2(), v3 = new Vector2(), v4 = new Vector2();
            switch (rotation)
            {
                case Texture.Rotation.Top:
                    v1 = new Vector2(x, y);
                    v2 = new Vector2(x + elementWidth, y);
                    v3 = new Vector2(x + elementWidth, y - elementHeight);
                    v4 = new Vector2(x, y - elementHeight);
                    break;
                case Texture.Rotation.Right:
                    v1 = new Vector2(x + elementWidth, y);
                    v2 = new Vector2(x + elementWidth, y - elementHeight);
                    v3 = new Vector2(x, y - elementHeight);
                    v4 = new Vector2(x, y);
                    break;
                case Texture.Rotation.Bottom:
                    v1 = new Vector2(x + elementWidth, y - elementHeight);
                    v2 = new Vector2(x, y - elementHeight);
                    v3 = new Vector2(x, y);
                    v4 = new Vector2(x + elementWidth, y);
                    break;
                case Texture.Rotation.Left:
                    v1 = new Vector2(x, y - elementHeight);
                    v2 = new Vector2(x, y);
                    v3 = new Vector2(x + elementWidth, y);
                    v4 = new Vector2(x + elementWidth, y - elementHeight);
                    break;
            }
            //Clear zone
            //GL.Begin(BeginMode.Quads);
            //{
            //    GL.Color3(Color.Black);
            //    GL.Vertex2(v1);
            //    GL.Vertex2(v2);
            //    GL.Vertex2(v3);
            //    GL.Vertex2(v4);
            //}
            //GL.End();

            //mapping texture
            texture.Bind();
            GL.Begin(BeginMode.Quads);
            {
                GL.Color4(Color4.Transparent);
                GL.TexCoord2(0, 0); 
                GL.Vertex2(v1);
                GL.TexCoord2(1, 0);
                GL.Vertex2(v2);
                GL.TexCoord2(1, 1);
                GL.Vertex2(v3);
                GL.TexCoord2(0, 1);
                GL.Vertex2(v4);
            }
            GL.End();
        }

        #region Level Methods
        public void RenderLevel(Level level)
        {
            DrawMap(level.MapInstance);
            DrawTanks(level.Tanks);
        }

        public bool TankCanMove(Level level, AbstractTank tank, Texture.Rotation rotation)
        {
            PointF pos = TankPositionOnMap(tank);
            List<MapObject.Types> nextMapObjectType = NextMapObjects(level, tank, rotation);
            List<MapObject.Types> currentMapObjectType = CurrentMapObjects(level, tank, rotation);
            nextMapObjectType.RemoveAll(x => x.Equals(MapObject.Types.FOREST) || x.Equals(MapObject.Types.EMPTY));
            currentMapObjectType.RemoveAll(x => x.Equals(MapObject.Types.FOREST) || x.Equals(MapObject.Types.EMPTY));

            switch (rotation)
            {
                case Texture.Rotation.Top:
                    return windowHeight/2 - ((int) pos.Y)*elementHeight - tank.Y == 0
                               ? nextMapObjectType.Count.Equals(0)
                               : currentMapObjectType.Count.Equals(0);
                case Texture.Rotation.Bottom:
                    return windowHeight/2 - ((int) pos.Y)*elementHeight - elementHeight - tank.Y == -elementHeight
                               ? nextMapObjectType.Count.Equals(0)
                               : currentMapObjectType.Count.Equals(0);
                case Texture.Rotation.Right:
                    return -windowWidth/2 + ((int) pos.X)*elementWidth + elementWidth - tank.X == elementWidth
                               ? nextMapObjectType.Count.Equals(0)
                               : currentMapObjectType.Count.Equals(0);
                case Texture.Rotation.Left:
                    return -windowWidth/2 + ((int) pos.X)*elementWidth - tank.X == 0
                               ? nextMapObjectType.Count.Equals(0)
                               : currentMapObjectType.Count.Equals(0);
            }
            return false;
        }

        private List<MapObject.Types> CurrentMapObjects(Level level, AbstractTank tank, Texture.Rotation rotation)
        {
            PointF tankPositionOnMap = TankPositionOnMap(tank);
            float fX = (float)Math.Round(tankPositionOnMap.X, 0), fY = (float)Math.Round(tankPositionOnMap.Y, 0);
            List<MapObject.Types> objects = new List<MapObject.Types>();

            switch (rotation)
            {
                case Texture.Rotation.Top:
                    objects.Add(level.MapInstance[(int)tankPositionOnMap.Y][(int)tankPositionOnMap.X].Type);
                    if (!tank.Y.Equals((int) (windowHeight/2 - fY*elementHeight)) &&
                        tankPositionOnMap.X - ((int)tankPositionOnMap.X) > 0)
                    {
                        objects.Add(level.MapInstance[(int) tankPositionOnMap.Y][(int) tankPositionOnMap.X + 1].Type);
                    }
                    break;
                case Texture.Rotation.Bottom:
                    objects.Add(level.MapInstance[(int)tankPositionOnMap.Y][(int)tankPositionOnMap.X].Type);
                    if (!(tank.Y - ElementHeight).Equals((int) (windowHeight/2 - (fY + 1)*elementHeight)) &&
                        tankPositionOnMap.X - ((int) tankPositionOnMap.X) > 0)
                    {
                        objects.Add(level.MapInstance[(int) tankPositionOnMap.Y][(int) tankPositionOnMap.X + 1].Type);
                    }
                    break;
                case Texture.Rotation.Right:
                    objects.Add(level.MapInstance[(int)tankPositionOnMap.Y][(int)tankPositionOnMap.X].Type);
                    if (!(tank.X + elementWidth).Equals((int) (-windowWidth/2 + (fX + 1)*ElementHeight)) &&
                        tankPositionOnMap.Y - ((int) tankPositionOnMap.Y) > 0)
                    {
                        objects.Add(level.MapInstance[(int) tankPositionOnMap.Y + 1][(int) tankPositionOnMap.X].Type);
                    }
                    break;
                case Texture.Rotation.Left:
                    objects.Add(level.MapInstance[(int)tankPositionOnMap.Y][(int)tankPositionOnMap.X].Type);
                    if (!tank.X.Equals((int) (-windowWidth/2 + fX*elementWidth)) &&
                        tankPositionOnMap.Y - ((int) tankPositionOnMap.Y) > 0)
                    {
                        objects.Add(level.MapInstance[(int) tankPositionOnMap.Y + 1][(int) tankPositionOnMap.X].Type);
                    }
                    break;
            }
            return objects;
        }

        private List<MapObject.Types> NextMapObjects(Level level, AbstractTank tank, Texture.Rotation rotation)
        {
            PointF tankPositionOnMap = TankPositionOnMap(tank);
            List<MapObject.Types> objects = new List<MapObject.Types>();

            switch (rotation)
            {
                case Texture.Rotation.Top:
                    if (((int)(tankPositionOnMap.Y)).Equals(0))
                    {
                        return new List<MapObject.Types> { MapObject.Types.TEMPORARY };
                    }
                    objects.Add(level.MapInstance[(int)tankPositionOnMap.Y - 1][(int)tankPositionOnMap.X].Type);//get current tank pos MapObject
                    if (tankPositionOnMap.X - ((int)tankPositionOnMap.X) > 0)//if tank is on two MapObjects
                    {
                        objects.Add(level.MapInstance[(int)tankPositionOnMap.Y - 1][(int)tankPositionOnMap.X + 1].Type);
                    }
                    break;
                case Texture.Rotation.Bottom:
                    if (((int)(tankPositionOnMap.Y)).Equals(19))
                    {
                        return new List<MapObject.Types> { MapObject.Types.TEMPORARY };
                    }
                    objects.Add(level.MapInstance[(int)tankPositionOnMap.Y + 1][(int)tankPositionOnMap.X].Type);
                    if (tankPositionOnMap.X - ((int)tankPositionOnMap.X) > 0)
                    {
                        objects.Add(level.MapInstance[(int)tankPositionOnMap.Y + 1][(int)tankPositionOnMap.X + 1].Type);
                    }
                    break;
                case Texture.Rotation.Right:
                    if (((int)(tankPositionOnMap.X)).Equals(18))
                    {
                        return new List<MapObject.Types> { MapObject.Types.TEMPORARY };
                    }
                    objects.Add(level.MapInstance[(int)tankPositionOnMap.Y][(int)tankPositionOnMap.X + 1].Type);
                    if (tankPositionOnMap.Y - ((int)tankPositionOnMap.Y) > 0)
                    {
                        objects.Add(level.MapInstance[(int)tankPositionOnMap.Y + 1][(int)tankPositionOnMap.X + 1].Type);
                    }
                    break;
                case Texture.Rotation.Left:
                    if (((int)(tankPositionOnMap.X)).Equals(0))
                    {
                        return new List<MapObject.Types> { MapObject.Types.TEMPORARY };
                    }
                    objects.Add(level.MapInstance[(int)tankPositionOnMap.Y][(int)tankPositionOnMap.X - 1].Type);
                    if (tankPositionOnMap.Y - ((int)tankPositionOnMap.Y) > 0)
                    {
                        objects.Add(level.MapInstance[(int)tankPositionOnMap.Y + 1][(int)tankPositionOnMap.X - 1].Type);
                    }
                    break;
            }
            return objects;
        }

        private PointF TankPositionOnMap(AbstractTank tank)
        {
            return new PointF((tank.X + windowWidth / 2) / ElementWidth,
                              (tank.Y - windowHeight / 2) / ElementHeight * -1);
        }

        #endregion

        #region Map Methods

        public void DrawMap(MapObject[][] map)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color.Black);
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[i].Length; j++)
                {
                    MapTextureSwitcher(j, i, map[i][j].Type);
                }
        }

        public void DrawMapPart(int x, int y, MapObject.Types type)
        {
            MapTextureSwitcher(x, y, type);
        }

        private void MapTextureSwitcher(int mapPartX, int mapPartY, MapObject.Types type)
        {
            switch (type)
            {
                case MapObject.Types.EMPTY: DrawMapPart(mapPartX, mapPartY, 0);
                    break;
                case MapObject.Types.BRICK: DrawMapPart(mapPartX, mapPartY, 1);
                    break;
                case MapObject.Types.CONCRETE: DrawMapPart(mapPartX, mapPartY, 2);
                    break;
                case MapObject.Types.WATER: DrawMapPart(mapPartX, mapPartY, 3);
                    break;
                case MapObject.Types.FOREST: DrawMapPart(mapPartX, mapPartY, 4);
                    break;
                case MapObject.Types.BASE: DrawMapPart(mapPartX, mapPartY, 5);
                    break;
            }
        }

        private void DrawMapPart(int x, int y, int textureIndex)
        {
            DrawTexture((int) (-windowWidth/2 + x*elementWidth),
                        (int) (windowHeight/2 - y*elementHeight),
                        mapTextureList[textureIndex], Texture.Rotation.Top);
        }

        #endregion Map Methods

        #region Tank Methods
        
        public void DrawTanks(IList<AbstractTank> tanks)
        {
            foreach (var tank in tanks)
            {
                switch (tank.type)
                {
                    case AbstractTank.Type.PlayerNormal:
                        DrawTexture(tank.X, tank.Y, tankTextureList[0], tank.rotation);
                        break;
                    case AbstractTank.Type.PlayerFast:
                        // TODO: texture of fast tank
                        DrawTexture(tank.X, tank.Y, tankTextureList[0], tank.rotation);
                        break;
                }
            }
        }

        public void DrawTank(int x, int y, AbstractTank.Type type, Texture.Rotation rotation)
        {
            switch (type)
            {
                case AbstractTank.Type.PlayerNormal:
                    DrawTexture(x, y, tankTextureList[0], rotation);
                    //DrawTank(x, y, 0);
                    break;
                case AbstractTank.Type.PlayerFast:
                    break;
            }
        }

        #endregion Tank Methods

        #region Bullet Methods

        #endregion Bullet Methods

        #region Bonus's Methods

        #endregion Bonus's Methods
    }
}