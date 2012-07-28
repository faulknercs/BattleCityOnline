using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.GameLib
{
    /// <summary>
    /// Represents game proccess
    /// </summary>
    public class ServerProcess
    {
        /// <summary>
        /// Add new player to the game
        /// </summary>
        /// <param name="player">Player, which will be added to the game</param>
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        /// <summary>
        /// Calculate next game state (position of tanks at next moment, etc)
        /// </summary>
        public void NextState()
        {

        }

        private void CreatePlayersTanks()
        {
            
        }

        private void ChangePlayersState()
        {

        }

        private Level currentMap;
        private IList<Player> players = new List<Player>();
        private bool gameOver = false;
    }
}
