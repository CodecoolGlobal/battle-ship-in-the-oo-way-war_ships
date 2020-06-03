using System;
using System.Collections.Generic;


namespace BattleShips
{
    class Player
    {

        public Ocean playerOcean;
        private string Name;
        private bool IsComp;
        private bool IsLoser;

        public Player(string name)
        {
            List<Ship> ships = new List<Ship>();
            this.Name = name;
            this.playerOcean = new Ocean(ships); 
        }

        public int enemyAttack(char[] coords)
        {
            foreach (var ship in playerOcean.GetShips())
            {
                for
            }
        }
        
        public bool checkIfLoser()
        {
            foreach (var ship in playerOcean.GetOceanShips())
            {

            }
        }


    }
}
