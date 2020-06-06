using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleShips
{
    public class Ocean
    {
        private static int HEIGHT = 10;
        private static int WIDTH = 10;
        private List<List<Square>> Squares;
        public List<Ship> Ships {get; set;}

        private Random randBase = new Random();
        public Ocean()
        {
            this.Squares = GenerateSquares();
            this.Ships = new List<Ship>();
        }
        public Ocean(List<Ship> ships)
        {
            this.Squares = GenerateSquares();
            this.Ships = ships;
            InsertShips();
        }
        public void AddShip(int size, bool ishorizontal, Point startingpoint) 
        {
            Ship shipToAdd = new Ship(size, ishorizontal, startingpoint);
            Ships.Add(shipToAdd);
        }
        
        protected void InsertShips()
        {
            Ship _ship;
            for (int j = 0; j < Ships.Count; j++) 
            {
                _ship = Ships[j];
                var ship_x = _ship.GetStartingPoint().X;
                var ship_y = _ship.GetStartingPoint().Y;
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
        protected void InsertShipsList(List<Ship> shipsList)
        {
            Ship _ship;
            for (int j = 0; j < shipsList.Count; j++) 
            {
                _ship = shipsList[j];
                var ship_x = _ship.GetStartingPoint().X;
                var ship_y = _ship.GetStartingPoint().Y;
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
        protected List<List<Square>> GenerateSquares() 
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
        public bool IsCoordShip(Point coord)
        {
            int coordX = coord.X;
            int coordY = coord.Y;

            foreach (Ship ship in Ships) 
            {
                int shipX = ship.GetStartingPoint().X;
                int shipY = ship.GetStartingPoint().Y;
                var shipXRange = Enumerable.Range(shipX, ship.IsShipHorizontal()? ship.Squares.Count : 1);
                var shipYRange = Enumerable.Range(shipY, ship.IsShipHorizontal()? 1 : ship.Squares.Count);
                if (shipXRange.Contains(shipX) && shipYRange.Contains(shipY))
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
        public Ship RandomlyGenerateShip(int size, List<Ship> ships)
        {
            var randIsHorizontal = randBase.Next(0,100) < 50 ? true : false;
            Ship newShip;
            Point startingPoint;
            while (true)
            {
                startingPoint = new Point(randBase.Next(0, WIDTH) - size, randBase.Next(0, HEIGHT));
                newShip = new Ship(size, randIsHorizontal, startingPoint);
                if (CheckIfNewShipCorrect(newShip, ships))
                {
                    break;
                }
            }
            return newShip;
        }

        public List<Ship> RandomlyGenerateShips(int maximumSize)
        // Method to generate random ships inside Borad size with one of each 
        {
            List<Ship> generatedShips = new List<Ship>();
            for (int size = maximumSize; size < 0; size--)
            {
                generatedShips.Add(RandomlyGenerateShip(size, generatedShips));
            }
            return generatedShips;
        }
        public bool CheckIfNewShipCorrect(Ship checkShip, List<Ship> existingShips)
        {
            if (!CheckIfShipInOcean(checkShip))
            {
                return false;
            }
            List<Point> coordsOffLimits = new List<Point>();
            Point coordCheckShip = new Point(-1, -1);
            foreach (var _ship in existingShips)
            {
                Point offLimitsRangeStart = new Point(_ship.GetStartingPoint().X - 1, _ship.GetStartingPoint().Y - 1);
                Point offLimitsRangeEnd = new Point(_ship.IsShipHorizontal() ? _ship.GetStartingPoint().X + _ship.Squares.Count + 1 : _ship.GetStartingPoint().X + 1
                                                    ,_ship.IsShipHorizontal() ? _ship.GetStartingPoint().Y + 1 : _ship.GetStartingPoint().Y + _ship.Squares.Count + 1);
                for (int ctrx = offLimitsRangeStart.X; ctrx < offLimitsRangeEnd.X + 1; ctrx++)
                {
                    for (int ctry = offLimitsRangeStart.Y; ctry < offLimitsRangeEnd.Y + 1; ctry++)
                    {
                        coordsOffLimits.Add(new Point(ctrx, ctry));
                    }
                }                
            }
            for (int i = 0; i < checkShip.Squares.Count; i++)
                coordCheckShip = new Point(checkShip.IsShipHorizontal() ? checkShip.GetStartingPoint().X + i : checkShip.GetStartingPoint().X,
                                           checkShip.IsShipHorizontal() ? checkShip.GetStartingPoint().Y : checkShip.GetStartingPoint().Y + i);
                if (coordsOffLimits.Contains(coordCheckShip))
                {
                    return false;
                }
            return true;
        }
        protected bool CheckIfShipInOcean(Ship checkShip)
        {
            if (checkShip.IsShipHorizontal())
            {
                if (checkShip.GetStartingPoint().X + checkShip.Squares.Count > WIDTH)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (checkShip.GetStartingPoint().Y + checkShip.Squares.Count > HEIGHT)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}