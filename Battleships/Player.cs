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
        // missAgain = 0 - miss, already shot at; missOk = 1 - miss, new shot; shotAgain = 2 - shot, already shot; shotOk = 3 - shot, new shot
        private int EffectOnAttack(Square square)
        {
            int missAgain = 0;
            int missOk  = 1;
            int shotAgain = 2;
            int shotOk = 3;

            if (square.isHit)
            {
                if (square.GetSquare() == "S")
                {
                    return shotAgain;
                }
                else
                {
                    return missAgain;
                }
            }
            else
            {   
                if (square.GetSquare() == "S")
                {   
                    square.isHit = true;
                    return shotOk;
                }
                else
                {
                    square.isHit = true;
                    return missOk;
                }
            }
        }
        // effectOnAttack - missAgain = 0 - miss, already shot at; missOk = 1 - miss, new shot; shotAgain = 2 - shot, already shot; shotOk = 3 - shot, new shot; 4 - shot ok, ship sanked
        //
        public int enemyAttack(Point coords)
        {   
            int effectOnAttack;
            bool isShipSank = false;
            List<Ship> playerShips = playerOcean.Ships;
            for (int shipctr = 0; shipctr < playerShips.Count; shipctr++)
            {
                Ship checkShip = playerShips[shipctr];
                for (int ctr = 0; ctr < checkShip.Squares.Count; ctr++)
                {
                    if (checkShip.IsShipHorizontal())
                    {
                       if (coords.X == checkShip.GetStartingPoint().X + ctr && coords.Y == checkShip.GetStartingPoint().Y)
                       {
                           if (checkShip.ShipSank().Equals(true))
                           {
                               effectOnAttack = 4;
                           }
                           effectOnAttack = EffectOnAttack(checkShip.Squares[ctr]);
                       }
                    }
                    else
                    {
                        if (coords.X == checkShip.GetStartingPoint().X && coords.Y == checkShip.GetStartingPoint().Y + ctr)
                       {
                            if (checkShip.ShipSank().Equals(true))
                           {
                               effectOnAttack = 4;
                           }
                           effectOnAttack = EffectOnAttack(checkShip.Squares[ctr]);
                       }
                    }   
                }
            }
            return effectOnAttack;
            
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
