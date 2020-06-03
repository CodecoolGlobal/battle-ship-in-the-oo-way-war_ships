using System;
using System.Collections.Generic;


namespace BattleShips
{
    class Game
    {
        private DateTime startTime;
        private DateTime endTime;
        private string gameTypeName;
        private List<Player> playersList;
        private Player currentPLayer;


        public Game(string gameType, List<Player> playersListInput) 
        {
            
            this.startTime = DateTime.Now;
            this.playersList = playersListInput;
            this.gameTypeName = gameType;


        }

        public Player PlayerTurn()
        {
            playersList.Find();
        }

        public string[] PlayerShot(string playerName, int[] coords) 
        {
            this.currentPLayer = playerName;
            return coords;
        }

        public Player ChangePlayer()
        {
            if( playersList.IndexOf(currentPLayer) == 0 )
            {
                this.currentPLayer = playersList[1];
            }
            
            this.currentPLayer = playersList [0];
        }   

        public Player GameWinner(List playersList)
        {
            foreach (var player in playersList)
            {
                for( int i = ; i   )
            }
        }

    }
}
