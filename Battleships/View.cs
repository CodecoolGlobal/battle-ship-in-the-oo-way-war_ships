using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleShips
{
    class View
    {
        private static Dictionary<string, string> SYMB = new Dictionary<string, string>()
        {
            {"vert", "\u2500"},
            {"hor", "\u2502"},
            {"ltc", "\u250C"},
            {"rtc", "\u2510"},
            {"lbc", "\u2514"},
            {"rbc", "\u2518"},
            {"t", "\u252C"},
            {"revt", "\u2534"},
            {"cross", "\u253C"},
            {"shot", "\u2668"},
            {"selected", "\u2588"},
            {"ship", "\u2693"},
            {"norm", " "}
        };
        private Dictionary<string, ConsoleColor> consoleColorScheme = new Dictionary<string, ConsoleColor>();
        private Dictionary<string, Color> drawingColorScheme = new Dictionary<string, Color>();
        private string[] mainMenuOptions;
        private string[] settingsMenuOptions;
        private int consoleWidth;
        public View(int Width, int Height) 
        {

            consoleColorScheme.Add("selected_back", ConsoleColor.Blue);
            consoleColorScheme.Add("selected_front", ConsoleColor.White);

            drawingColorScheme.Add("selected_back", Color.Blue);
            drawingColorScheme.Add("selected_front", Color.WhiteSmoke);
            drawingColorScheme.Add("ship_hit", Color.Yellow);
            drawingColorScheme.Add("ship_sank", Color.Red);
            drawingColorScheme.Add("miss", Color.Brown);      

        }

        private void BackgroundColorChanger()
        {
            Console.BackgroundColor = consoleColorScheme["back"];
        }
        private void ForegroundColorChanger()
        {
            Console.ForegroundColor = consoleColorScheme["front"];
        }
        private void ConsoleColorReset()
        {
            Console.ResetColor();
        }
        private void DisplayFrameTop(string title, int width)
        {
            Console.Clear();
            Console.WriteLine("\u250f" + String.Concat(Enumerable.Repeat("\u2501", width)) + "\u2513");
            int titleLenEven = title.Length % 2 == 0 ? title.Length : title.Length + 1;
            Console.WriteLine('\u2503'.ToString() + new string(' ', (width - titleLenEven) / 2 + 1) + 
                                $"{title.ToUpper()}" + new string(' ', (width - titleLenEven) / 2 + 1) + "\u2503");
        }
        
        private void DisplayFrameBottom(int width, bool needEnter)
        {
            if (needEnter)
            {   
                string msg = "Press ENTER to close this window..";
                int msgLenEven = msg.Length % 2 == 0 ? msg.Length : msg.Length + 1;
                Console.WriteLine('\u2503'.ToString() + new string(' ', (width - msgLenEven) / 2) + 
                                $"{msg}" + new string(' ', (width - msgLenEven) / 2) + "\u2513");
                Console.WriteLine("\u2516" + String.Concat(Enumerable.Repeat("\u2501", width - 2)) + "\u251a");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine('\u2503'.ToString() + $"{String.Empty:width}" + "\u2503");
                Console.WriteLine("\u2516" + String.Concat(Enumerable.Repeat("\u2501", width - 2)) + "\u251a");
            }
        }
        private void DisplayTable(Dictionary<string, string> optionsDictionary)
        {   var optionsKeys = optionsDictionary.Keys.ToArray();
            Console.WriteLine(String.Format("  {0, -30} {1, 25}", "Option", "Value"));
            for (int ctropt = 0; ctropt < optionsKeys.Length; ctropt++)
            {
                Console.WriteLine(String.Format("  {0, -30} {1, 25}", optionsKeys[ctropt], optionsDictionary[optionsKeys[ctropt]]));
            }
        }
        
        public void DisplayMessage(string info, string errorMessage)
        {
            Console.Clear();
            DisplayFrameTop(info, Console.WindowWidth);
            DisplayHalfScreenEmpty();
            Console.WriteLine(errorMessage + "\n\nPress any key...");
            Console.ReadKey();
        }
        private void DisplayHalfScreenEmpty()
        {
            for (int ctr = 0; ctr < (Console.WindowHeight - 2) / 2; ctr++)
            {
                Console.WriteLine(String.Empty);
            }
        }
        private void DisplayRemainingScreenEmpty(int contentHeight, int bordersLines)
        {   
            var remainingHeight = Console.WindowHeight - contentHeight - bordersLines;
            for (int ctr = 0; ctr < remainingHeight / 2; ctr++)
            {
                Console.WriteLine(String.Empty);
            }
        }
        private string GetSquareDisplay(Square square)
        {
            if (square.isHit)
            {
                if (square.GetSquare() == "S")
                {
                    return SYMB["shot"];
                }
                else
                {
                    return SYMB["miss"];
                }
            }
            else
            {   
                if (square.GetSquare() == "S")
                {   
                    return SYMB["ship"];
                }
                else
                {
                    return SYMB["norm"];
                }
            }
        }
        private string GetBoardElementDisplay(int xCoord, int yCoord, Ocean oceanToCheck, Point selectedPoint)
        {
            if (xCoord == 0 && yCoord == 0)
            {
                return SYMB["ltc"];
            }
            else if (xCoord == 0 && yCoord == BattleshipsController.HEIGHT * 2)
            {
                return SYMB["lbc"];
            }
            else if (yCoord == 0 && xCoord % 2 == 1)
            {
                return SYMB["t"];
            }
            else if (yCoord == 0 && xCoord == BattleshipsController.WIDTH * 2)
            {
                return SYMB["rtc"];
            }
            else if (yCoord == BattleshipsController.HEIGHT && xCoord % 2 == 1)
            {
                return SYMB["revt"];
            }
            else if (yCoord == BattleshipsController.HEIGHT && xCoord == BattleshipsController.WIDTH * 2)
            {
                return SYMB["rbc"];
            }
            else if (yCoord % 2 == 0 && xCoord % 2 == 1)
            {
                return SYMB["hor"];
            }
            else if (xCoord % 2 == 0 && yCoord % 2 == 1)
            {
                return SYMB["vert"];
            }
            else if (yCoord % 2 == 0 && xCoord % 2 == 0)
            {
                return SYMB["cross"];
            }
            else if (yCoord % 2 == 1 && xCoord % 2 == 1)
            {
                if (selectedPoint.X == xCoord / 2 && selectedPoint.Y == yCoord)
                {
                    return SYMB["selected"];
                }
                else
                {
                    return GetSquareDisplay(oceanToCheck.Squares[yCoord / 2][xCoord / 2]);
                }
            }
            else
            {
                return String.Empty;
            }

        }




        // public methods
        public Point PlayerBoardsAndAttack(Player curPlayer, Player othPlayer)
        {
            var selectionPoint = new Point(BattleshipsController.WIDTH / 2, BattleshipsController.HEIGHT / 2);
            ConsoleKey keyPressed = ConsoleKey.A;
            do
            {
                DisplayFrameTop("choose field to attack", Console.WindowWidth);
                DisplayPlayerBoardSelection(curPlayer,othPlayer, selectionPoint);
                Console.WriteLine("\n\n\n               CHOOSE FIELD TO ATTACK AND CONFIRM WITH ENTER\n\n");
                DisplayFrameBottom(Console.WindowWidth, false);
                keyPressed = Console.ReadKey().Key;
                if (keyPressed == ConsoleKey.UpArrow && selectionPoint.Y > 0)
                {
                    selectionPoint.Y--;
                }
                else if (keyPressed == ConsoleKey.DownArrow && selectionPoint.Y < BattleshipsController.HEIGHT - 1)
                {
                    selectionPoint.Y++;
                }
                else if (keyPressed == ConsoleKey.RightArrow && selectionPoint.X < BattleshipsController.WIDTH - 1)
                {
                    selectionPoint.X++;
                }
                else if (keyPressed == ConsoleKey.LeftArrow && selectionPoint.X > 0)
                {
                    selectionPoint.X--;
                }

            } while (!(keyPressed == ConsoleKey.Enter));
            return selectionPoint;

        }
        public void PlayerBoardsAttackResult(Player curPlayer, Player othPlayer, string msgOnAttack)
        {   
            ConsoleKey keyPressed = ConsoleKey.A;
            var selectionPoint = new Point(-1, -1);
            do
            {   
                DisplayFrameTop("choose field to attack", Console.WindowWidth);
                DisplayPlayerBoardSelection(curPlayer,othPlayer, selectionPoint);
                Console.WriteLine($"\n\n\n               {msgOnAttack}\n\n");
                DisplayFrameBottom(Console.WindowWidth, false);
                keyPressed = Console.ReadKey().Key;
            } while (keyPressed == ConsoleKey.Enter);
        }
        public void DisplayPlayerBoardSelection(Player curPlayer, Player othPlayer, Point selected)
        {
            var plrOcean = curPlayer.playerOcean;
            var othOcean = othPlayer.playerOcean;
            List<List<string>> plrBoard = new List<List<string>>();
            List<List<string>> othBoard = new List<List<string>>();
            Point negPoint = new Point(-1, -1);

            for (int ctry = 0; ctry < BattleshipsController.HEIGHT * 2 + 1; ctry++)
            {
                List<string> plrLstBoard = new List<string>();
                List<string> othLstBoard = new List<string>();
                for (int ctrx = 0; ctrx < BattleshipsController.WIDTH * 2 + 1; ctrx++)
                {   
                    plrLstBoard.Add(GetBoardElementDisplay(ctrx, ctry, plrOcean, negPoint));
                    othLstBoard.Add(GetBoardElementDisplay(ctrx, ctry, othOcean, selected));
                }
                plrBoard.Add(plrLstBoard);
                othBoard.Add(othLstBoard);
            }


            //Printing lines
            Console.WriteLine($"  {curPlayer.Name, 15} {othPlayer.Name, 30}");
            var othPrint = String.Empty;
            var plrPrint = String.Empty;
            for (int prnty = 0; prnty < plrBoard.Count; prnty++)
            {
                for (int prntx = 0; prntx < plrBoard.Count; prntx++)
                {   
                    plrPrint += plrBoard[prnty][prntx];
                    othPrint += othBoard[prnty][prntx];
                }
                Console.WriteLine("  " + othPrint + "  " + plrPrint);
            }
        }
        // public List<Ship> PutShipsOnBoard(string info, )
        // {
        //     var keyList = options.Keys.ToList();
        //     int selectedKeyNum = 0;
        //     string pointer = " >>>";
        //     string ifPointer;
        //     string optionDisplayed;
        //     while (true)
        //     {
        //         DisplayFrameTop("Put ships on Your ocean", Console.WindowWidth);
        //         Console.WriteLine();
        //     }
        // }
        public string Menu(string title, string info, Dictionary<string,string> options)
        {
            Console.Clear();
            var keyList = options.Keys.ToArray();
            int selectedKeyNum = 0;
            string pointer = " >>>";
            string ifPointer;
            string optionDisplayed;
            ConsoleKey pressedKey = ConsoleKey.A;
            do
            {
                DisplayFrameTop(title, Console.WindowWidth);
                Console.WriteLine(info);
                for (int ctr = 0; ctr < keyList.Length; ctr++)
                {   
                    ifPointer = selectedKeyNum == ctr ? pointer : "    ";
                    optionDisplayed = options[keyList[ctr]];
                    Console.WriteLine($"{ifPointer} {optionDisplayed}");
                }
                DisplayRemainingScreenEmpty(keyList.Length, 5);
                DisplayFrameBottom(Console.WindowWidth, false);
                pressedKey = Console.ReadKey().Key;
                if (pressedKey == ConsoleKey.UpArrow && selectedKeyNum > 0)
                {
                    selectedKeyNum--;
                }
                else if (pressedKey == ConsoleKey.DownArrow && selectedKeyNum < options.Count - 1)
                {
                    selectedKeyNum++;
                }
            } while (!pressedKey.Equals(ConsoleKey.Enter));
            return keyList[selectedKeyNum];
        }

        public void DisplayGameStatistics(Game currentGame)
        {
            DisplayFrameTop("game statistics", Console.WindowWidth);

            var currGameTimeStr = (DateTime.Now - currentGame.startTime).ToString("c");
            var currGameType = currentGame.gameTypeName; 
            var currGamePlayersStat = currentGame.PlayersToTable(); // 3lines

            Console.WriteLine(String.Format("  {0, -25} - {1, -25}", "Game time",currGameTimeStr));
            Console.WriteLine(String.Format("  {0, -25} - {1, -25}", "Game time",currGameTimeStr));
            foreach (var line in currGamePlayersStat)
            {
                Console.WriteLine("  " + line);
            }
            DisplayRemainingScreenEmpty(5, 2);
            DisplayFrameBottom(Console.WindowWidth, true);
        }
        public string GetStringData(string query, string dataName)
        {
            DisplayFrameTop($"{query}", Console.WindowWidth);
            DisplayHalfScreenEmpty();
            Console.WriteLine($"  Please provide {dataName} and hit Enter");
            var result = Console.ReadLine();
            return result;
            
        }
        public int GetIntData(string query, string dataName, int[] rangeEnds)
        {
            while (true)
            {
                DisplayFrameTop($"{query}", Console.WindowWidth);
                DisplayHalfScreenEmpty();
                Console.WriteLine($"  Please provide {dataName} [{rangeEnds[0]}, {rangeEnds[1]}] and hit Enter");
                try
                {
                    var result = int.Parse(Console.ReadLine());
                    if (result >= rangeEnds[0] && result <= rangeEnds[1])
                    {
                        return result;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    DisplayMessage("Invalid value"," Please enter an integer in correct range");
                }
            }
        }
    }
}