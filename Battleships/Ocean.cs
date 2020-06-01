using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShips
{
    public class Ocean
    {
        private static int HEIGHT = 10;
        private static int WIDTH = 10;
        private List<List<Square>> Squares;
        private List<Ship> Ships;
        private Random randBase = new Random();

        public Ocean(List<Ship> ships)
        {
            this.Squares = GenerateSquares(ships);
            this.Ships = ships;
        }
        public void AddShip(int size, bool isvert, int[] startingpoint) 
        {
            Ship shipToAdd = new Ship(size, isvert, startingpoint);
            Ships.Add(shipToAdd);
        }
        
        public void InsertShipsList() 
        {
            Ship _ship;
            for (int j = 0; j < Ships.Count; j++) 
            {
                _ship = Ships[j];
                int ship_x = _ship.GetStartingPoint()[0];
                int ship_y = _ship.GetStartingPoint()[1];
                if (_ship.IsShipHorizontal()) 
                {
                    for (int i = 0; i < _ship.Squares.Count; i++) 
                    {
                        Squares[ship_y][ship_x + i] = _ship.Squares[i];
                    }
                }
                else 
                {
                    for (int i = 0; i < _ship.Squares.Count; i++) 
                    {
                        Squares[ship_y + 1][ship_x] = _ship.Squares[i];
                    }
                }
            }
        }
        protected List<List<Square>> GenerateSquares(List<Ship> ships) 
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                List<Square> squareList = new List<Square>();
                Squares.Add(squareList);
                for (int j = 0; j < WIDTH; j++) 
                {
                    Square newSquare = new Square(" ", false);
                    Squares[i].Add(newSquare);
                }
            }
            InsertShipsList();
            return Squares;
        }
        public List<List<Square>> GetOceanSquares() 
        {
            return Squares;
        }
        // Getting List<Ship> of ships on Ocean
        public List<Ship> GetOceanShips()
        {
            return Ships;
        }
        // Checking coordinates of a shot if they belong to Ship coords format int[2] [Xcoord, Ycoord] ex. A5 = [0,5]
        public bool IsCoordShip(int[] coord)
        {
            int coordX = coord[0];
            int coordY = coord[1];

            foreach (Ship ship in Ships) 
            {
                int shipX = ship.GetStartingPoint()[0];
                int shipY = ship.GetStartingPoint()[1];
                var shipXRange = Enumerable.Range(shipX, ship.IsShipHorizontal()? ship.Squares.Count : 1);
                var shipYRange = Enumerable.Range(shipY, ship.IsShipHorizontal()? 1 : ship.Squares.Count);
                if (shipXRange.Contains(shipX))
                {
                    return true;
                }
            }
            return false;
        }
        /*Method to create random ship with coditions:
        - putting ship on board that does not overlaps with other ships - it has to get the coords of all existing Ships in obj field
        - not only not overlaps but they can not touch - there has to be expanded list of coords out of limits
        - 50% horizontal
        - if ship can not be placed with chosen arrangement it flips and tries again with differnt one
        - raises error when it is not possible
        */
        public Ship RandomlyGenerateShip(int size)
        {
            var randIsHorizontal = randBase.Next(0,100) < 50 ? true : false;
            while (true)
            {
                break;
            }
            return Ships[0];
        }
        public List<Ship> RandomlyGenerateShips()
        {
            return Ships;
        }
    }
}