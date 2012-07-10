using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BattleCity.GameClient.GUI
{
    /// <summary>
    /// Supports text rendering using OpenTK
    /// </summary>
    class GuiText
    {
        public GuiText()
        {

        }

        public String Value
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

        public void Render()
        {
            if (Value == null || Value == "")
                return;
        }

        private Font textFont;
        private String textValue;
        private int textWidth;
        private int textHeight;
    }
}
