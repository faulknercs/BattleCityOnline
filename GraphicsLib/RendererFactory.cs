using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace BattleCity.GraphicsLib
{
    /// <summary>
    /// Factory, which produces IRendererImpl classes according to OpenGL version
    /// </summary>
    public class RendererFactory
    {
        /// <summary>
        /// Gets instanse of factory
        /// </summary>
        public static RendererFactory Instance 
        {
            get
            {
                if (instance == null)
                    instance = new RendererFactory();
                return instance;
            }
        }

        /// <summary>
        /// Gets IRendererImpl according to OpenGL version
        /// </summary>
        /// <returns></returns>
        public IRendererImpl CreateRenderer()
        {
            return rendererImpl;
        }

        private RendererFactory()
        {
            // TODO: Add version choosing
            Version glVersion = new Version(GL.GetString(StringName.Version).Substring(0, 3));
            //if (glVersion.Major == 2)
                rendererImpl = new GL2_Renderer();
            //else
                
        }

        private IRendererImpl rendererImpl = null;
        private static RendererFactory instance = null;
    }
}
