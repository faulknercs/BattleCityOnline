using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameLib
{
    class GameMode
    {
        public enum Mode : byte
        {
            CLASSIC,        //Classical mode (one team defends its base, another one attacks trying to destroy the base)
            TDM,                //Team deathmatch (two teams attacking each other) without bases
            TDMB,               //Team deathmatch with bases (both teams have their own base)
            DM                  //Deathmatch (every player fights for himself) without bases
        }
        public GameMode (GameMode.Mode m)
        {
            mode = m;
            switch (mode)
            {
                case Mode.CLASSIC:
                    break;
                case Mode.TDM:
                    break;
                case Mode.TDMB:
                    break;
                case Mode.DM:
                    break;
            }
        }
        private Mode mode;
    }
}
