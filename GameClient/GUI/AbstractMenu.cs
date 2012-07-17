using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        protected IRendererImpl renderer;
        private float menuWidth;
        private float menuHeight;
    }
}
