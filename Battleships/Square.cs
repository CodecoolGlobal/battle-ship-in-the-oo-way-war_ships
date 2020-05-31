namespace BattleShips
{
    public class Square
    {
        private static char SYMBOL = 'X';
        private string square;

        public bool isHit;


        public Square(string square, bool isHit)

        {
            this.square = square;
            this.isHit = false;
        }

        public string toString(bool isHit, string square)
        {
            if (isHit == false)
            {
                return string.Format($"[{0}]", ' ');
            }

            else
            {
                return string.Format($"[{0}]", SYMBOL);
            }

        }
    }
}

    