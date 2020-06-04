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
        private Ship playerShip;
        private List<List<Squares>> playerSquares;

        public Player(string name)
        {
            List<Ship> ships = new List<Ship>();
            this.Name = name;
            this.playerOcean = new Ocean(ships); 
            this.playerShip = new Ship(startingPoint);
            this.playerSquares = new Ocean(squares);
            
        }

        public int enemyAttack(Point coords)
        {
            foreach (var ship in playerOcean.GetShips())
            {
                if (ship
            }
        }
        
        public bool checkIfLoser()
        {
            foreach (var squares in playerOcean.GetOceanSquares())
            {
                foreach (var square in squares)
                {
                    if 
                }
            }
        }


    }
}
