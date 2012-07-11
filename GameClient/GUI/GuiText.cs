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
                    // TODO: needs to recalculate text parameters
                }
            }
        }

        public int Width 
        {
            get
            {
                return textWidth;
            }
        }

        public int Height
        {
            get
            {
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

        private Font textFont;
        private String textValue;
        private Texture textTexture;
        private int textWidth;
        private int textHeight;
        private bool needToRenderTexture;
        private bool needToCalculateSize;
    }
}
