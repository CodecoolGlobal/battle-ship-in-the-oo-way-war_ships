using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;


namespace BattleShips
{
    class Game
    {
        private DateTime startTime;
        private DateTime endTime;
        //Game type pvp or pvc
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

        public int PlayerShot(Player otherPlayer, Point coords)        
        {
            return otherPlayer.EnemyAttack(coords);
        }

        protected void ChangePlayer()
        {
            currentPLayer = OtherPlayer();
        }   

        public Player GameWinner(Player currentPLayer)
        {
            if (currentPLayer.checkIfLoser() == true & OtherPlayer().checkIfLoser() == false)
            {
                return currentPLayer;
            }
            return OtherPlayer();

        }

        public bool GameEnd(List <Player> playersList)
        {
            foreach(var player in playersList)
            {
                if (player.checkIfLoser() == false)
                {
                    return true;
                }
            }   
            return false;
        }

    }
}
