namespace BattleShips
{
    public class Square
    {
        private static char SYMBOL = 'X';
        private string aSquare;

        public bool isHit {get; set;}


        public Square(string square, bool isHit)

        {
            this.aSquare = square;
            this.isHit = false;
        }
        public string GetSquare() {
            return aSquare;
        }

        public string toString(bool isHit)
        {
            if (isHit == false)
            {
                return string.Format($"[{0}]", aSquare);
            }

            else
            {
                return string.Format($"[{0}]", SYMBOL);
            }

        }
    }
}

    