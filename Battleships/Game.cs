using System;
using System.Collections.Generic;
using System.Drawing;


namespace BattleShips
{
    class Game
    {
        public DateTime startTime {get;}
        private DateTime endTime;
        public TimeSpan gameTime {get; set;}
        //Game type pvp or pvc
        public string gameTypeName {get;}
        public List<Player> playersList {get; set;}
        private Player currentPLayer;


        public Game(string gameType, List<Player> playersListInput) 
        {
            
            this.startTime = DateTime.Now;
            this.playersList = playersListInput;
            this.gameTypeName = gameType;

            while (true)
            {

            }

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
                    endTime = DateTime.Now;
                    gameTime = endTime - startTime;
                    return true;
                }
            }   
            return false;
        }
        public string[] PlayersToTable()
        {
            var playersTableData = new string[playersList.Count + 1];
            playersTableData[0] = String.Format(" {0, -15}| {1, -15}| {2, -10}| {3, - 40}", "player name", "player type"
                                                , "Remaining ships").ToUpper();
            Player curPlayer;
            List<Ship> curShips;
            string shipsRemaining;                                   
            for (int i = 0; i < playersList.Count; i++)
            {   
                curPlayer = playersList[i];
                curShips = curPlayer.playerOcean.Ships;
                shipsRemaining = String.Empty;
                foreach (var _ship in curShips)
                {
                    if (_ship.ShipSank() == 0)
                    {   
                        var _size = _ship.Squares.Count;
                        shipsRemaining += BattleshipsController.shipsSizesAndNames[_size] + $" [{_size}]" + ", ";
                    }
                }
                shipsRemaining.Trim().TrimEnd(',');
                playersTableData[i] = String
                                        .Format(" {0, -15}| {1, -15}| {2, -10}| {3, -45}", curPlayer.Name, curPlayer.isComp ? "human" : "CPU"
                                        , shipsRemaining);
            }
            return playersTableData;
        }

    }
}
