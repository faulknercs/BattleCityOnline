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
            width = bitmap.Width;
            height = bitmap.Height;

            glTextureHandle = GL.GenTexture();
            Bind();

            GetDataFromBitmap(bitmap);
        }

        /// <summary>
        /// Bind a named texture to a Texture2D target (GL_TEXTURE_2D in OpenGL).
        /// </summary>
        public virtual void Bind()
        {
            GL.BindTexture(TextureTarget.Texture2D, glTextureHandle);
        }

        protected void GetDataFromBitmap(Bitmap bitmap)
        {
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
            bitmap.UnlockBits(bitmapData);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        }

        /// <summary>
        /// Gets texture width.
        /// </summary>
        public virtual int Width 
        { 
            get
            {
                return width;
            }
        }

        /// <summary>
        /// Gets texture height
        /// </summary>
        public virtual int Height 
        { 
            get 
            {
                return height;
            }
        }

        /// <summary>
        /// Creates empty texture.
        /// </summary>
        protected Texture()
        {
            glTextureHandle = GL.GenTexture();
        }

        private int width;
        private int height;
        private int glTextureHandle;
    }
}