using System.Drawing;
using BattleCity.GameClient.GUI;
using BattleCity.GameLib;
using OpenTK;
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
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color.Black);
            for (int i = 0; i < map.GetInternalForm().Length; i++)
                for (int j = 0; j < map.GetInternalForm()[i].Length; j++)
                    switch (map.GetInternalForm()[i][j].Type)
                    {
                        case MapObject.Types.EMPTY: DrawMapPart(i, j, 0);
                            break;
                        case MapObject.Types.BRICK: DrawMapPart(i, j, 1);
                            break;
                        case MapObject.Types.CONCRETE: DrawMapPart(i, j, 2);
                            break;
                        case MapObject.Types.WATER: DrawMapPart(i, j, 3);
                            break;
                        case MapObject.Types.FOREST: DrawMapPart(i, j, 4);
                            break;
                        case MapObject.Types.BASE: DrawMapPart(i, j, 5);
                            break;
                    }
        }

        public void drawMap(int x, int y, MapObject.Types type)
        {
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

        private void DrawMapPart(int x, int y, int textureIndex)
        {
            Vector2 v1 = new Vector2(-windowWidth / 2 + y * elementWidth, windowHeight / 2 - x * elementHeight);
            Vector2 v2 = new Vector2(-windowWidth / 2 + y * elementWidth + elementWidth,
                                   windowHeight / 2 - x * elementHeight);
            Vector2 v3 = new Vector2(-windowWidth / 2 + y * elementWidth + elementWidth,
                           windowHeight / 2 - x * elementHeight - elementHeight);
            Vector2 v4 = new Vector2(-windowWidth / 2 + y * elementWidth, windowHeight / 2 - x * elementHeight - elementHeight);
            //Clear zone
            GL.Begin(BeginMode.Quads);
            {
                GL.Color3(Color.Black);
                GL.Vertex2(v1);
                GL.Vertex2(v2);
                GL.Vertex2(v3);
                GL.Vertex2(v4);
            }
            GL.End();

            //mapping texture
            textureList[textureIndex].Bind();
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

        #endregion Map Methods

        #region Tank Methods

        #endregion Tank Methods

        #region Bullet Methods

        #endregion Bullet Methods

        #region Bonus's Methods

        #endregion Bonus's Methods
    }
}