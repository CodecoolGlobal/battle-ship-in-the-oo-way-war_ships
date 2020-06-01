using System;
using System.Collections.Generic;

namespace BattleShips
{
    public class Ocean
    {
        private static int HEIGHT = 10;
        private static int WIDTH = 10;
        private List<List<Square>> Squares;
        private List<Ship> Ships;

        public Ocean(List<Ship> ships)
        {
            this.Squares = GenerateSquares(ships);
            this.Ships = ships;
        }
        public void AddShip(int size, bool isvert, int[] startingpoint) {
            Ship shipToAdd = new Ship(size, isvert, startingpoint);
            Ships.Add(shipToAdd);
        }
        
        public void InsertShipsList() {
            Ship _ship;
            for (int j = 0; j < Ships.Count; j++) {
                _ship = Ships[j];
                int ship_x = _ship.GetStartingPoint()[0];
                int ship_y = _ship.GetStartingPoint()[1];
                if (_ship.IsShipHorizontal()) {
                    for (int i = 0; i < _ship.Squares.Count; i++) {
                        Squares[ship_y][ship_x + i] = _ship.Squares[i];
                    }
                }
                else {
                    for (int i = 0; i < _ship.Squares.Count; i++) {
                        Squares[ship_y + 1][ship_x] = _ship.Squares[i];
                    }
                }
            }
        }
        protected List<List<Square>> GenerateSquares(List<Ship> ships) {
            for (int i = 0; i < HEIGHT; i++){
                List<Square> squareList = new List<Square>();
                Squares.Add(squareList);
                for (int j = 0; j < WIDTH; j++) {
                    Square newSquare = new Square(" ", false);
                    Squares[i].Add(newSquare);
                }
            }
            return Squares;
        }
        public List<List<Square>> GetOceanSquares() {
            return Squares;
        }

        public List<Ship> GetShips()
        {
            return this.Ships;
        }
    }
}