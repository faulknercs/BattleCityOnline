using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameClient.GUI
{
    /// <summary>
    /// Interface of rendering subsystem. 
    /// Allows to use different OpenGL versions (and different renderer versions).
    /// </summary>
    internal interface IRendererImpl
    {
        /// <summary>
        /// Render 2D texture with lower left corner coordinates at (x, y). 
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="x">X-Coordinate of lower left corner</param>
        /// <param name="y">Y-Coordinate of lower left corner</param>
        void Render(Texture texture, float x, float y);

        /// <summary>
        /// Render 2D texture with coordinates, which are listed in coords.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="coords"></param>
        void Render(Texture texture, float[] coords);
    }
}
