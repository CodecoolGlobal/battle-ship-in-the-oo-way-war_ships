namespace BattleShips
{
    public class Square
    {
        private static string SYMBOL = " ";
        private string aSquare;

        public bool isHit {get; set;}
        public Square()
        {
            this.aSquare = SYMBOL;
            this.isHit = false;
        }

        public Square(string asquare)
        {
            this.aSquare = asquare;
            this.isHit = false;
        }
        public Square(string asquare, bool ishit)

        {
            this.aSquare = asquare;
            this.isHit = ishit;
        }
        public string GetSquare() {
            return aSquare;
        }

        public string toString()
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

    