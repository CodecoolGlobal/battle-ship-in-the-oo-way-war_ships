using System;
using System.Collections.Generic;
using System.Drawing;



namespace BattleShips
{
    public class Player
    {

        public Ocean playerOcean;
        public string Name {get;}
        // Read-only name
        public bool isComp {get;}
        // Read-only type
        public int shotsFired {get;}
        //Read-only shotsFired

        public Player(bool isCPU, string name)
        {       
            this.Name = name;
            this.playerOcean = new Ocean();
            this.isComp = isCPU;
        }
        public Player(bool isCPU, string name, List<Ship> ships) : this(isCPU, name)
        {       
            this.playerOcean = new Ocean(ships); 
        }
        // MISSAGAIN = 0 - miss, already shot at; MISSOK = 1 - miss, new shot; SHOTAGAIN = 2 - shot, already shot; SHOTOK = 3 - shot, new shot
        private int EffectOnAttack(Square square)
        {
            if (square.isHit)
            {
                if (square.GetSquare() == "S")
                {
                    return BattleshipsController.SHOTAGAIN;
                }
                else
                {
                    return BattleshipsController.MISSAGAIN;
                }
            }
            else
            {   
                if (square.GetSquare() == "S")
                {   
                    square.isHit = true;
                    return BattleshipsController.SHOTOK;
                }
                else
                {
                    square.isHit = true;
                    return BattleshipsController.MISSOK;
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
                    if (checkShip.ShipSank() > 0)
                    {
                        effectOnAttack = BattleshipsController.SHOTSANKED;
                    }   
                }
            }

            return effectOnAttack;
            
        }
        
        public bool checkIfLoser()
        {
            foreach (var ship in playerOcean.Ships)
            {
                if (ship.ShipSank() == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
