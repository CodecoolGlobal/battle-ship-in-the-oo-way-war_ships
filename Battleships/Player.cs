using System;
using System.Collections.Generic;
using System.Drawing;


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

        public string GetName()
        {
            return Name;
        }

        public int enemyAttack(Point coords)
        {
            playerOcean.GetOceanShips();
        }
        
        public bool checkIfLoser()
        {
            foreach (var ship in playerOcean.GetOceanShips())
            {

            }
        }


    }
}
