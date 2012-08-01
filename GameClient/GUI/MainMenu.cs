using System;
using System.Drawing;
using System.Collections.Generic;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using BattleCity.GraphicsLib;

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
            //DrawBackGround();
            renderer.SetColor(textColor);
            //calculate text position
            float x = 0;
            float y = 30;
            for (int i = 0; i < labelTextures.Length; ++i)
            {
                x = -labelTextures[i].Width / 2;
                y -= labelTextures[i].Height + 5;
                renderer.SetColor(i == menuItemPointer ? Color4.Red : textColor);
                renderer.Render(labelTextures[i], x, y);
            }
        }

        /// <summary>
        /// Overriden from abstract menu. Provides control of main menu
        /// </summary>
        /// <param name="keys">Pressed key</param>
        /// <returns>GameState</returns>
        public override GameState GetStateByKey(KeyboardKeyEventArgs keys)
        {
            switch(keys.Key)
            {
                case Key.Escape:
                    return GameState.EXIT;
                case Key.Down:
                    IncreaseMenuPointer();
                    break;
                case Key.Up:
                    DecreaseMenuPointer();
                    break;
                case Key.Enter:
                    return GetChoiceResult();
            }
            return GameState.MAINMENU;
        }

        private void Init()
        {
            //load background
            //backGroundTexture = new Texture(new Bitmap(Properties.Resources.main_background));
            labelTextures = new TextTexture[5];
            textFont = new Font(FontFamily.GenericMonospace, 22, FontStyle.Bold, GraphicsUnit.Pixel); //Incapsulate it in factory in the future
            textColor = Color4.White;

            labelTextures[0] = new TextTexture(textFont, Properties.StringItems.strSinglePlayer);
            labelTextures[1] = new TextTexture(textFont, Properties.StringItems.strMultiPlayer);
            labelTextures[2] = new TextTexture(textFont, Properties.StringItems.strOptions);
            labelTextures[3] = new TextTexture(textFont, Properties.StringItems.strAuthors);
            labelTextures[4] = new TextTexture(textFont, Properties.StringItems.strExit);
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

        private void IncreaseMenuPointer()
        {
            menuItemPointer++;
            if (menuItemPointer >= labelTextures.Length)
                menuItemPointer = 0;
        }

        private void DecreaseMenuPointer()
        {
            menuItemPointer--;
            if (menuItemPointer < 0)
                menuItemPointer = labelTextures.Length - 1;
        }

        private GameState GetChoiceResult()
        {
            switch (menuItemPointer)
            {
                case 0:
                    return GameState.SINGLEPL;
                case 1:
                    return GameState.NETWORK;
                case 2:
                    return GameState.OPTIONS;
                case 3:
                    return GameState.CREDITS;
                case 4:
                    return GameState.EXIT;
                default:
                    return GameState.MAINMENU;
            }
        }

        private Texture backGroundTexture;

        private Font textFont;
        private Color4 textColor;

        private Texture[] labelTextures;
        private int menuItemPointer;
    }
}
