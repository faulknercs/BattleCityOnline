using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Input;
using BattleCity.GraphicsLib;

namespace BattleCity.GameClient.GUI
{
    /// <summary>
    /// Represents game menus. 
    /// Using bridge design pattern
    /// </summary>
    internal abstract class AbstractMenu
    {
        public AbstractMenu(float menuWidth, float menuHeight)
        {
            this.menuWidth = menuWidth;
            this.menuHeight = menuHeight;
            renderer = RendererFactory.Instance.CreateRenderer();
        }

        /// <summary>
        /// Render menu with its elements
        /// </summary>
        public abstract void Render();

        /// <summary>
        /// Gets menu width
        /// </summary>
        public float Width
        {
            get
            {
                return menuWidth;
            }
        }

        /// <summary>
        /// Gets menu height
        /// </summary>
        public float Height
        {
            get
            {
                return menuHeight;
            }
        }

        /// <summary>
        /// Provides menu control by keyboard. Gets game state according to pressed key.
        /// </summary>
        /// <param name="key">Pressed key</param>
        /// <returns>Game state</returns>
        public abstract GameState GetStateByKey(KeyboardKeyEventArgs keys);

        protected IRendererImpl renderer;
        private float menuWidth;
        private float menuHeight;
    }
}
