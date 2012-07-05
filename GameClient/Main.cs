using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameClient
{
    class ClientMain
    {
        // TODO: Change it in the future.
        public static void Main(String[] args)
        {
            using(Game g = new Game(320, 240))
            {
                g.Run(30);
            }
            
        }
    }
}
