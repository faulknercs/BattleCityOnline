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
            foreach (Texture label in labelTextures)
            {
                x = -label.Width / 2;
                y -= label.Height + 5;
                renderer.Render(label, x, y);
            }

            //renderer.Render(singlePlayerLabel, );
        }

        private void Init()
        {
            //load background
            //backGroundTexture = new Texture(new Bitmap(Properties.Resources.main_background));
            labelTextures = new TextTexture[5];
            textFont = new Font(FontFamily.GenericMonospace, 22, FontStyle.Bold, GraphicsUnit.Pixel); //Incapsulate it in factory in the future
            textColor = Color4.White;

            singlePlayerLabel = new TextTexture(textFont, Properties.StringItems.strSinglePlayer);
            networkGameLabel = new TextTexture(textFont, Properties.StringItems.strMultiPlayer);
            optionsLabel = new TextTexture(textFont, Properties.StringItems.strOptions);
            authorsLabel = new TextTexture(textFont, Properties.StringItems.strAuthors);
            exitLabel = new TextTexture(textFont, Properties.StringItems.strExit);

            labelTextures[0] = singlePlayerLabel;
            labelTextures[1] = networkGameLabel;
            labelTextures[2] = optionsLabel;
            labelTextures[3] = authorsLabel;
            labelTextures[4] = exitLabel;
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
        // TODO: Maybe array will be better
        private TextTexture singlePlayerLabel;
        private TextTexture networkGameLabel;
        private TextTexture optionsLabel;
        private TextTexture authorsLabel;
        private TextTexture exitLabel;

        private TextTexture[] labelTextures;
    }
}
