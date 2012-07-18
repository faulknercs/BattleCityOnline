using System;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace BattleCity.GameClient.GUI
{
    /// <summary>
    /// Rendering subsystem for OpenGL 2.0 version
    /// </summary>
    internal class GL2_Renderer : IRendererImpl
    {
        public void Render(Texture texture, float x, float y)
        {
            texture.Bind();
            // TODO: test this class
            GL.Begin(BeginMode.Quads);
            {
                GL.TexCoord2(0, 0);
                GL.Vertex2(x, y + texture.Height);
                GL.TexCoord2(1, 0);
                GL.Vertex2(x + texture.Width, y + texture.Height);
                GL.TexCoord2(1, 1);
                GL.Vertex2(x + texture.Width, y);
                GL.TexCoord2(0, 1);
                GL.Vertex2(x, y);
            }
            GL.End();
        }

        public void Render(Texture texture, float[] coords)
        {
            if (coords.Length < 8)
                throw new ArgumentOutOfRangeException("coord", "Incorrect coordinate massive");
            // TODO: thinks, it's not effective, should remake it in the future
            texture.Bind();
            Vector2 v1 = new Vector2(coords[0], coords[1]);
            Vector2 v2 = new Vector2(coords[2], coords[3]);
            Vector2 v3 = new Vector2(coords[4], coords[5]);
            Vector2 v4 = new Vector2(coords[6], coords[7]);

            GL.Begin(BeginMode.Quads);
            {
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

        public void Render(Texture texture, float x1, float y1, float x2, float y2)
        {
            texture.Bind();
            GL.Begin(BeginMode.Quads);
            {
                GL.TexCoord2(0, 0);
                GL.Vertex2(x1, y2);
                GL.TexCoord2(1, 0);
                GL.Vertex2(x2, y2);
                GL.TexCoord2(1, 1);
                GL.Vertex2(x2, y1);
                GL.TexCoord2(0, 1);
                GL.Vertex2(x1, y1);
            }
            GL.End();
        }

        public void SetColor(OpenTK.Graphics.Color4 color)
        {
            GL.Color4(color);
        }

        public void Resize(int width, int height)
        {
            GL.Viewport(0, 0, width, height);
            //set new projection whith bottom left corner coordinates (-w,-h), (0, 0) - is center
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-width / 1, width / 2, -height / 2, height / 2, -1, 1);

            GL.MatrixMode(MatrixMode.Modelview);
        }
    }
}
