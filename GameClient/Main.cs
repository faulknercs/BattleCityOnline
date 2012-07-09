using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameClient
{
    internal class ClientMain
    {
        // TODO: Change it in the future.
        public static void Main(String[] args)
        {
            //base 380x400
            int width = 500;
            int height = Convert.ToInt32((400.0 / 380.0) * width);
            using (Game g = new Game(width, height))
            {
                g.Run(30);
            }
        }
    }
}