using System.Collections.Generic;
using BattleCity.GameLib;

namespace BattleCity.DedicatedServer
{
    public class Round
    {
        public Round(GameMode mode, Map map, List<Player> playerList)
        {
            Mode = mode;
            Map = map;
            PlayerList = playerList;
        }

        public GameMode Mode { get; set; }

        public Map Map { get; set; }

        public bool State { get; set; }

        public List<Player> PlayerList { get; set; }
    }
}