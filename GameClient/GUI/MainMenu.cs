using System;
using System.Drawing;
using System.Collections.Generic;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace BattleCity.GameClient.GUI
{
    /// <summary>
    /// Represents a main menu of the game. Player can choose game modes and begin game from here.
    /// </summary>
    internal class MainMenu
    {
        public MainMenu(float windowWidth, float windowHeight)
        {
            this.windowHeight = windowHeight;
            this.windowWidth = windowWidth;
            Init();
        }

        public void Render()
        {
            DrawBackGround();
        }

        private void Init()
        {
            //load background
            //...
            
            textFont = new Font(FontFamily.GenericMonospace, 12, GraphicsUnit.Pixel); //Incapsulate it in factory in the future
            textColor = Color4.White;

            singlePlayerLabel = new GuiText(textFont, textColor, Properties.StringItems.strSinglePlayer);
            networkGameLabel = new GuiText(textFont, textColor, Properties.StringItems.strMultiPlayer);
            optionsLabel = new GuiText(textFont, textColor, Properties.StringItems.strOptions);
            exitLabel = new GuiText(textFont, textColor, Properties.StringItems.strExit);
        }

        private void DrawBackGround()
        {
            backGroundTexture.Bind();
            GL.Color4(Color4.White);
            float x = windowWidth / 2;
            float y = windowWidth / 2;
            GL.Begin(BeginMode.Quads);
            {
                GL.TexCoord2(0, 0);
                GL.Vertex2(-x, y);

                GL.TexCoord2(1, 0);
                GL.Vertex2(x, y);

                GL.TexCoord2(1, 1);
                GL.Vertex2(x, -y);

                GL.TexCoord2(0, 1);
                GL.Vertex2(-x, -y);
            }
            GL.End();
        }

        private float windowHeight;
        private float windowWidth;

        private Texture backGroundTexture;

        private Font textFont;
        private Color4 textColor;

        private GuiText singlePlayerLabel;
        private GuiText networkGameLabel;
        private GuiText optionsLabel;
        private GuiText exitLabel;
    }
}
