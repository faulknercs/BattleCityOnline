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
    internal class GuiText
    {
        public GuiText(Font font)
        {
            this.TextFont = font;
        }

        public GuiText(Font font, Color4 color)
            : this(font)
        {
            this.TextColor = color;
        }

        public GuiText(Font font, Color4 color, String text)
            : this(font, color)
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
        /// Gets or sets text color
        /// </summary>
        public Color4 TextColor { get; set; }

        /// <summary>
        /// Returns text texture width
        /// </summary>
        public int Width
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
        public int Height
        {
            get
            {
                if (needToCalculateSize)
                    CalculateSize();
                return textHeight;
            }
        }

        /// <summary>
        /// Render text
        /// </summary>
        public void Render()
        {
            if (Text == null || Text == "")
                return;

            if (needToRenderTexture)
            {
                RenderTexture();
                needToRenderTexture = false;
            }

            textTexture.Bind();
            GL.Color4(TextColor);
            
            //render code
            GL.Begin(BeginMode.Quads);
            
            GL.TexCoord2(0, 0);
            GL.Vertex2(0, Height);

            GL.TexCoord2(1, 0);
            GL.Vertex2(Width, Height);

            GL.TexCoord2(1, 1);
            GL.Vertex2(Width, 0);

            GL.TexCoord2(0, 1);
            GL.Vertex2(0, 0);

            GL.End();
        }

        private void CalculateSize()
        {
            using (Graphics g = Graphics.FromImage(new Bitmap(1, 1)))
            {
                SizeF size = g.MeasureString(Text, textFont);
                textWidth = (int)Math.Ceiling(size.Width);
                textHeight = (int)Math.Ceiling(size.Height);
            }
        }

        private void RenderTexture()
        {
            Bitmap bitmap = new Bitmap(Width, Height);
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                g.DrawString(Text, textFont, Brushes.White, rect);

                textTexture = new Texture(bitmap);
            }
        }

        private Font textFont;
        private String textValue;
        private Texture textTexture;
        private int textWidth;
        private int textHeight;
        private bool needToRenderTexture = true;
        private bool needToCalculateSize = true;
    }
}