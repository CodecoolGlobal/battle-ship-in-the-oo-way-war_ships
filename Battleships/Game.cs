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
        public Player ChangePlayerTurn()
        {
            return OtherPlayer();
        }
        protected Player OtherPlayer()
        {
            int index = playersList.IndexOf(currentPLayer);
            return playersList[index < playersList.Count ? index + 1 : index - 1];
        }

        public string[] PlayerShot(string playerName, int[] coords) 
        {
            currentPLayer = playerName;
            return coords;
        }

        protected void ChangePlayer()
        {
            currentPLayer = OtherPlayer();
        }   

        public Player GameWinner(List playersList)
        {
            if(currentPLayer.checkIfLoser == true)
            {
                return OtherPlayer();
            }

            else if( OtherPlayer.checkIfLoser == true)
            {
                return currentPLayer;
            }            
        }

        public bool GameEnd(List playersList)
        {
            foreach(var player in playersList)
            {
                if (player.GameWinner)
                {
                    return false;
                }
            }
        }

    }
}
