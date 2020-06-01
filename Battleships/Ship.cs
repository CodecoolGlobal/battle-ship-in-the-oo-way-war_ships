using System;
using System.Collections.Generic;

namespace BattleShips
{
    public class Ship 
    {

        public List<Square> Squares {get; set;}
        private bool isHorizontal;
        private int[] StartingPoint = new int[2];

        // Important note: coords are [x,y], which means that: Squares[y][x]
        public Ship(int size, bool ishorizontal, int[] startingPoint) 
        {
            
            List<Square> squares = new List<Square>();
            for (int i = 0; i < size; i++) 
            {
                squares[i] = new Square("S", false);
            }
            this.Squares = squares;
            this.isHorizontal = ishorizontal;
            this.StartingPoint = startingPoint;
        }

        // Getting info about ship being horizontal or not
        public bool IsShipHorizontal() 
        {
            return isHorizontal;
        }
        // Getting ships starting point
        public int[] GetStartingPoint() 
        {
            return StartingPoint;
        }
        // Getting info if ship's sank
        public bool ShipSank() 
        {
            foreach (var square in Squares) 
            {
                if (square.isHit) 
                {
                    return false;
                }
            }
            return true;
        }
    }
}