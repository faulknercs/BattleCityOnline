using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

using OpenTK.Graphics.OpenGL;


namespace BattleCity.GameClient.GUI
{
    /// <summary>
    /// Incapsulates opengl textures
    /// </summary>
    class Texture
    {
        public Texture(Bitmap bitmap)
        {
            glTextureHandle = GL.GenTexture();
            Bind();

            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, 
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
            bitmap.UnlockBits(bitmapData);
            // TODO: make it!

        }

        public void Bind()
        {
            GL.BindTexture(TextureTarget.Texture2D, glTextureHandle);
        }

        private int glTextureHandle;
    }
}
