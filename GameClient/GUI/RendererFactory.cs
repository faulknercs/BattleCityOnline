using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameClient.GUI
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
            // TODO: make version chooser
            rendererImpl = new GL2_Renderer();
        }

        private IRendererImpl rendererImpl = null;
        private static RendererFactory instance = null;
    }
}
