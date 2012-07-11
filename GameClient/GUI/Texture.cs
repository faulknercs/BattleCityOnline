using System.Drawing;
using System.Drawing.Imaging;

using OpenTK.Graphics.OpenGL;

namespace BattleCity.GameClient.GUI
{
    /// <summary>
    /// Incapsulates opengl 2D textures
    /// </summary>
    internal class Texture
    {
        public Texture(Bitmap bitmap)
        {
            glTextureHandle = GL.GenTexture();
            Bind();

            Width = bitmap.Width;
            Height = bitmap.Height;

            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
            bitmap.UnlockBits(bitmapData);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        }

        /// <summary>
        /// Bind a named texture to a Texture2D target (GL_TEXTURE_2D in OpenGL).
        /// </summary>
        public void Bind()
        {
            GL.BindTexture(TextureTarget.Texture2D, glTextureHandle);
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        private int glTextureHandle;
    }
}