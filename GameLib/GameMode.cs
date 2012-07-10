using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameLib
{
    public class GameMode
    {
        public enum Mode : byte
        {
            CLASSIC,        //Classical mode (one team defends its base, another one attacks trying to destroy the base)
            TDM,                //Team deathmatch (two teams attacking each other) without bases
            TDMB,               //Team deathmatch with bases (both teams have their own base)
            DM                  //Deathmatch (every player fights for himself) without bases
        }
        public GameMode(Mode m)
        {
            mode = m;
            switch (mode)
            {
                case Mode.CLASSIC:
                    //                    modeName = "Classic";
                    break;
                case Mode.TDM:
                    //                    modeName = "Team Deathmatch";
                    break;
                case Mode.TDMB:
                    //                   modeName = "Team Deathmatch With Bases";
                    break;
                case Mode.DM:
                    //                    modeName = "Deathmatch";
                    break;
            }
        }
        public Mode mode { get; set; }
        //        private String modeName;
        //        public String getName() { return modeName; }
    }
}
