﻿using System;

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
            int width = 570;
            int height = 600;
            using (Game g = new Game(width, height))
            {
                g.Run(30);
            }
        }
    }
}