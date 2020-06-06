using System;
using System.Collections.Generic;
using System.Drawing;



namespace BattleShips
{
    public class Player
    {

        public Ocean playerOcean;
        private string Name;
        private bool isComp;
        private bool isLoser;
        public static int MISSAGAIN = 0;
        public static int MISSOK  = 1;
        public static int SHOTAGAIN = 2;
        public static int SHOTOK = 3;
        public static int SHOTSANKED = 4;
        public Player(string name, List<Ship> ships)
        {       
            this.Name = name;
            this.playerOcean = new Ocean(ships); 
        }
        public Player(string name)
        {       
            this.Name = name;
            this.playerOcean = new Ocean(); 
        }
        // MISSAGAIN = 0 - miss, already shot at; MISSOK = 1 - miss, new shot; SHOTAGAIN = 2 - shot, already shot; SHOTOK = 3 - shot, new shot
        private int EffectOnAttack(Square square)
        {
            if (square.isHit)
            {
                if (square.GetSquare() == "S")
                {
                    return SHOTAGAIN;
                }
                else
                {
                    return MISSAGAIN;
                }
            }
            else
            {   
                if (square.GetSquare() == "S")
                {   
                    square.isHit = true;
                    return SHOTOK;
                }
                else
                {
                    square.isHit = true;
                    return MISSOK;
                }
            }
        }
        // effectOnAttack - MISSAGAIN = 0 - miss, already shot at; MISSOK = 1 - miss, new shot; SHOTAGAIN = 2 - shot, already shot; SHOTOK = 3 - shot, new shot; 4 - SHOTSANKED, ship sanked
        // int type: 
        public int EnemyAttack(Point coords)
        {   
            int effectOnAttack = 0;
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
                           effectOnAttack = EffectOnAttack(checkShip.Squares[ctr]);
                       }
                    }
                    else
                    {
                        if (coords.X == checkShip.GetStartingPoint().X && coords.Y == checkShip.GetStartingPoint().Y + ctr)
                       {
                           effectOnAttack = EffectOnAttack(checkShip.Squares[ctr]);
                       }
                    }
                    if (checkShip.ShipSank().Equals(true))
                    {
                        effectOnAttack = SHOTSANKED;
                    }   
                }
            }

            return effectOnAttack;
            
        }
        // SWITCH to choose from used things with effectOnAttack
        
        public bool checkIfLoser()
        {
            foreach (var ship in playerOcean.Ships)
            {
                if (!ship.ShipSank())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
