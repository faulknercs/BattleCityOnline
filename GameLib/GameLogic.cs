using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameLib
{
    public class GameLogic
    {

        public void AddPlayer(IPlayer player)
        {
            players.Add(player);
        }

        private IList<IPlayer> players = new List<IPlayer>();
        private bool gameOver = false;
    }
}
