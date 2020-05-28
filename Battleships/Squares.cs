namespace BattleShips
{
    public class Squares
    {
        private static char SYMBOL = 'X';
        private string square;

        private bool isHit;


        public Squares(string square, bool isHit)

        {
            this.square = square;
            this.isHit = false;
        }



        public string toString(bool isHit, string square)
        {
            if (isHit == false)
            {
                return string.Format("[{0}]", ' ');
            }

            else
            {
                return string.Format("[{0}]", SYMBOL);
            }

        }
    }
}

    