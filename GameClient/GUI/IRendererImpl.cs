using System;

using OpenTK.Graphics;

namespace BattleCity.GameClient.GUI
{
    /// <summary>
    /// Interface of rendering subsystem. 
    /// Allows to use different OpenGL versions (and different renderer versions).
    /// </summary>
    public interface IRendererImpl
    {
        /// <summary>
        /// Render 2D texture with lower left corner coordinates at (x, y). 
        /// </summary>
        /// <param name="texture">Texture, which will be rendering</param>
        /// <param name="x">X-Coordinate of lower left corner</param>
        /// <param name="y">Y-Coordinate of lower left corner</param>
        void Render(Texture texture, float x, float y);

        /// <summary>
        /// Render 2D texture with coordinates, which are listed in coords.
        /// </summary>
        /// <param name="texture">Texture, which will be rendering</param>
        /// <param name="coords">Massive of coordinates.</param>
        void Render(Texture texture, float[] coords);

        /// <summary>
        /// Render 2D texture with coordinates of lower left corner (x1, y1)
        /// and coordinates of upper right corner (x2, y2).
        /// </summary>
        /// <param name="texture">Texture, which will be rendering</param>
        /// <param name="x1">X-Coordinate of lower left corner</param>
        /// <param name="y1">Y-Coordinate of lower left corner</param>
        /// <param name="x2">X-Coordinate of upper right corner</param>
        /// <param name="y2">Y-Coordinate of upper right corner</param>
        void Render(Texture texture, float x1, float y1, float x2, float y2);

        /// <summary>
        /// Sets current color
        /// </summary>
        /// <param name="color">color, which will be used</param>
        void SetColor(Color4 color);

        /// <summary>
        /// Resizes viewport.
        /// </summary>
        /// <param name="width">New width</param>
        /// <param name="height">New height</param>
        void Resize(int width, int height);
    }
}
