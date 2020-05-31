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
            foreach (var ship_ in Ships) {
                int ship_x = ship_.GetStartingPoint()[0];
                int ship_y = ship_.GetStartingPoint()[1];
                if (ship_.IsShipHorizontal()) {
                    for (int i = 0; i < ship_.Squares.Count; i++) {
                        Squares[ship_x + i][ship_y] = ship_.Squares[i];
                    }
                }
                else {
                    for (int i = 0; i < ship_.Squares.Count; i++) {
                        Squares[ship_x][ship_y + i] = ship_.Squares[i];
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
    }
}