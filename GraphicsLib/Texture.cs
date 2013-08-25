using System;
using System.Drawing;
using System.Drawing.Imaging;

using OpenTK.Graphics.OpenGL;

namespace BattleCity.GraphicsLib
{
    /// <summary>
    /// Incapsulates OpenGL 2D textures
    /// </summary>
    public class Texture : IDisposable
    {
        public Texture(Bitmap bitmap)
            : this()
        {
            width = bitmap.Width;
            height = bitmap.Height;
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
            if(isNPOTsupported)
            {
                potWidth = Width;
                potHeight = Height;
            }
            else
            {
                potWidth = (int)Math.Pow(2, Math.Ceiling(Math.Log(Width, 2)));
                potHeight = (int)Math.Pow(2, Math.Ceiling(Math.Log(Height, 2)));
            }
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, potWidth, potHeight, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, IntPtr.Zero);
            GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, bitmapData.Width, bitmapData.Height,
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
            CheckNPOT_Support();
        }

        #region NPOT support

        /// <summary>
        /// Gets texture coordinates of right corner (usualy 1)
        /// </summary>
        public float TextureXCoord
        {
            get
            {
                return isNPOTsupported ? 1 : (float)Width / potWidth;
            }
        }

        /// <summary>
        /// Gets texture coordinates of top corner (usualy 1)
        /// </summary>
        public float TextureYCoord
        {
            get
            {
                return isNPOTsupported ? 1 : (float)Height / potHeight;
            }
        }

        private void CheckNPOT_Support()
        {
            String ExtensionsRaw = GL.GetString(StringName.Extensions);
            String[] splitter = new String[] { " " };
            String[] Extensions = ExtensionsRaw.Split(splitter, StringSplitOptions.None);
            foreach(String extName in Extensions)
            {
                if(extName.Equals("GL_ARB_texture_non_power_of_two"))
                {
                    isNPOTsupported = true;
                    return;
                }
            }
        }

        private bool isNPOTsupported = false;
        private int potWidth;
        private int potHeight;

        #endregion

        public enum Rotation
        {
            Top,
            Bottom,
            Left,
            Right
        }

        public Rotation rotation { get; private set; }

        private int width;
        private int height;
        private int glTextureHandle;

        #region IDisposable support

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool manual)
        {
            if (!disposed)
            {
                if (manual)
                {
                    GL.DeleteTexture(glTextureHandle);
                    disposed = true;
                }
                else
                {
                    //GC.KeepAlive(this);
                    //Not able to delete resources at current OpenTK version
                    // TODO: Fix this, when possible
                }
            }
        }

        ~Texture()
        {
            Dispose(false);
        }

        private bool disposed;

        #endregion
    }
}