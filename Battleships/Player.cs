using System;

namespace BattleShips
{
    class Player : IEquatable<Player>
    {

        private Ocean PlayerOcean;
        private string Name;
        private bool IsComp;
        private bool IsLoser;

        public Player(string name)
        {
            this.Name = name;
            this.PlayerOcean = new Ocean(); 
        }

        public int enemyAttack(int[] coords)
        {
        }
        
        public bool checkIfLoser()
        {
            foreach (var ship in Ship);
        }


    }
}
