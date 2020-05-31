using System;

namespace BattleShips
{
<<<<<<< HEAD
    public class Player
=======
    class Player : IEquatable<Player>
>>>>>>> e2e07b1f272cdb4771f197e8dee6a94e06e3e28d
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
