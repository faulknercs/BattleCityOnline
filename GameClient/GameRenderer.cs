using System;
using BattleCity.GameClient.GUI;
using BattleCity.GameLib;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace BattleCity.GameClient
{
    /// <summary>
    /// Class, which is responsible for displaying the gameplay
    /// </summary>
    internal class GameRenderer
    {
        public GameRenderer(float windowWidth, float windowHeight, Texture[] textureList)
        {
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
            this.textureList = textureList;
            elementWidth = windowWidth / 19;
            elementHeight = windowHeight / 20;
        }

        private float windowWidth, windowHeight;
        private float elementWidth, elementHeight;
        private Texture[] textureList;

        #region Map Methods

        public void drawMap(Map map)
        {
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
        }

        public void refreshMap(int i, int j, MapObject.Types type)
        {
            double x = Convert.ToDouble(j);
            double y = Convert.ToDouble(i);
            switch (type)
            {
                case MapObject.Types.EMPTY: DrawMapPart(x, y, 0);
                    break;
                case MapObject.Types.BRICK: DrawMapPart(x, y, 1);
                    break;
                case MapObject.Types.CONCRETE: DrawMapPart(x, y, 2);
                    break;
                case MapObject.Types.WATER: DrawMapPart(x, y, 3);
                    break;
                case MapObject.Types.FOREST: DrawMapPart(x, y, 4);
                    break;
                case MapObject.Types.BASE: DrawMapPart(x, y, 5);
                    break;
            }
        }

        private void DrawMapPart(double leftX, double leftY, int textureIndex)
        {
            textureList[textureIndex].Bind();
            GL.Begin(BeginMode.Quads);

            GL.Color4(Color4.Transparent);
            GL.TexCoord2(0, 0);
            GL.Vertex3(-windowWidth / 2 + leftX * elementWidth, windowHeight / 2 - leftY * elementHeight, 0);
            GL.TexCoord2(1, 0);
            GL.Vertex3(-windowWidth / 2 + leftX * elementWidth + elementWidth, windowHeight / 2 - leftY * elementHeight, 0);
            GL.TexCoord2(1, 1);
            GL.Vertex3(-windowWidth / 2 + leftX * elementWidth + elementWidth, windowHeight / 2 - leftY * elementHeight - elementHeight, 0);
            GL.TexCoord2(0, 1);
            GL.Vertex3(-windowWidth / 2 + leftX * elementWidth, windowHeight / 2 - leftY * elementHeight - elementHeight, 0);

            GL.End();
        }

        #endregion Map Methods

        #region Tank Methods

        #endregion Tank Methods

        #region Bullet Methods

        #endregion Bullet Methods

        #region Bonus's Methods

        #endregion Bonus's Methods
    }
}