using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using OpenTK.Graphics.OpenGL;

namespace BattleCity.GameClient.GUI
{
    /// <summary>
    /// Supports text rendering using OpenTK
    /// </summary>
    class GuiText
    {
        public GuiText(String text)
        {
            this.Text = text;
        }

        public GuiText()
        {
            
        }

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

        public int Width 
        {
            get
            {
                if (needToCalculateSize)
                    CalculateSize();
                return textWidth;
            }
        }

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

            if(needToRenderTexture)
            {

            }

            textTexture.Bind();
            //render code

        }

        private void CalculateSize()
        {
            using(Graphics g = Graphics.FromImage(new Bitmap(0,0)))
            {
                SizeF size = g.MeasureString(Text, textFont);
                textWidth = (int)Math.Ceiling(size.Width);
                textHeight = (int)Math.Ceiling(size.Height);
            }
        }

        private Font textFont;
        private String textValue;
        private Texture textTexture;
        private int textWidth;
        private int textHeight;
        private bool needToRenderTexture;
        private bool needToCalculateSize;
    }
}
