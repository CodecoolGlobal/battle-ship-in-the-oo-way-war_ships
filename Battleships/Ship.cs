using System;
using System.Collections.Generic;
using System.Drawing;

namespace BattleShips
{
    public class Ship 
    {

        public List<Square> Squares {get; set;}
        private bool isHorizontal;
        private Point StartingPoint = new Point();

        // Important note: coords are [x,y], which means that: Squares[y][x]
        public Ship(int size, bool ishorizontal, Point startingPoint) 
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
        public Point GetStartingPoint() 
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