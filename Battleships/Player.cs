using System;
using System.Collections.Generic;
using System.Drawing;



namespace BattleShips
{
    public class Player
    {

        public Ocean playerOcean;
        private string Name;
        private bool IsComp;
        private bool IsLoser;
    

        public Player(string name)
        {       
            this.Name = name;
            this.playerOcean = new Ocean(ships); 
            
        }

        public int enemyAttack(Point coords)
        {
            foreach (var ship in playerOcean.GetOceanShips())
            {
                foreach( var square in ship.Squares)
                {
                    if (square[x][y] == coords)
                    {
                        if (square == square('S', false))
                        {

                        }
                    }
                        
                }
            }
        }
        
        public bool checkIfLoser()
        {
            foreach (var ship in playerOcean.GetOceanShips())
            {
                if (ship.ShipSank == false)
                {
                    return true;
                }
                return false;

            }
        }


    }
}
