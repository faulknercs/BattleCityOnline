using System;
using System.Drawing;
using System.Drawing.Text;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace BattleCity.GameClient.GUI
{
    /// <summary>
    /// Supports text rendering using OpenTK
    /// </summary>
    internal class TextTexture : Texture
    {
        public TextTexture(Font font)
        {
            this.TextFont = font;
        }

        public TextTexture(Font font, String text)
            : this(font)
        {
            this.Text = text;
        }

        /// <summary>
        /// Gets or sets text value
        /// </summary>
        public String Text
        {
            get
            {
                return textValue;
            }
            set
            {
                if (value != textValue)
                {
                    textValue = value;
                    needToCalculateSize = true;
                    needToRenderTexture = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets text font
        /// </summary>
        public Font TextFont
        {
            get
            {
                return textFont;
            }
            set
            {
                if (!value.Equals(textFont))
                {
                    textFont = value;
                    needToCalculateSize = true;
                    needToRenderTexture = true;
                }
            }
        }

        /// <summary>
        /// Returns text texture width
        /// </summary>
        public override int Width
        {
            get
            {
                if (needToCalculateSize)
                    CalculateSize();
                return textWidth;
            }
        }

        /// <summary>
        /// Returns text texture height
        /// </summary>
        public override int Height
        {
            get
            {
                if (needToCalculateSize)
                    CalculateSize();
                return textHeight;
            }
        }

        /// <summary>
        /// Overriden. Binds text texture to a Texture2D target (GL_TEXTURE_2D in OpenGL).
        /// </summary>
        public override void Bind()
        {
            base.Bind();
            if (needToRenderTexture)
                RenderTexture();
        }

        private void CalculateSize()
        {
            using (Graphics g = Graphics.FromImage(new Bitmap(1, 1)))
            {
                SizeF size = g.MeasureString(Text, textFont);
                textWidth = (int)Math.Ceiling(size.Width);
                textHeight = (int)Math.Ceiling(size.Height);
            }
            needToCalculateSize = false;
        }

        private void RenderTexture()
        {
            Bitmap bitmap = new Bitmap(Width, Height);
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                g.DrawString(Text, TextFont, Brushes.White, rect);
            }
            GetDataFromBitmap(bitmap);
            needToRenderTexture = false;
        }

        private Font textFont;
        private String textValue;

        private int textWidth;
        private int textHeight;
        private bool needToRenderTexture = true;
        private bool needToCalculateSize = true;
    }
}