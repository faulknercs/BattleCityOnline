﻿using System;
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
    internal class MainMenu : AbstractMenu
    {
        public MainMenu(float windowWidth, float windowHeight)
            : base(windowWidth, windowHeight)
        {
            Init();
        }

        /// <summary>
        /// Overridden. Render Main Menu with its elements
        /// </summary>
        public override void Render()
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
            //backGround has to have window size, or use other Render overload
            backGroundTexture.Bind();
            GL.Color4(Color4.White);
            float x = - Width / 2;
            float y = Height / 2;
            renderer.Render(backGroundTexture, x, y);
        }

        private Texture backGroundTexture;

        private Font textFont;
        private Color4 textColor;

        private GuiText singlePlayerLabel;
        private GuiText networkGameLabel;
        private GuiText optionsLabel;
        private GuiText exitLabel;
    }
}
