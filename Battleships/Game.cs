using System;

namespace BattleShips
{
    class Game
    {
        private DateTime startTime;
        private DateTime endTime;
        private string gameTypeName;
        private List<Player> playersList;
        private Player currentPLayer;


        public Game(string gameType, List<Player> playersListInput) {
            
            this.startTime = DateTime.Now;
            this.playersList = playersListInput;
            this.gameTypeName = gameType;


        }

        public Player PlayerTurn(){
            playersList.Find()
        }

        public string[] PlayerShot(string playerName, int[] coords) {

        }
    }
}
