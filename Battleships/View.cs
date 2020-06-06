using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleShips
{
    class View
    {
        private Dictionary<string, ConsoleColor> consoleColorScheme = new Dictionary<string, ConsoleColor>();
        private Dictionary<string, Color> drawingColorScheme = new Dictionary<string, Color>();
        private string[] mainMenuOptions;
        private string[] settingsMenuOptions;
        private int consoleWidth;
        public View(int Width, int Height) 
        {
            SetConsoleDimensions(Width, Height);

            consoleColorScheme.Add("selected_back", ConsoleColor.Blue);
            consoleColorScheme.Add("selected_front", ConsoleColor.White);

            drawingColorScheme.Add("selected_back", Color.Blue);
            drawingColorScheme.Add("selected_front", Color.WhiteSmoke);
            drawingColorScheme.Add("ship_hit", Color.Yellow);
            drawingColorScheme.Add("ship_sank", Color.Red);
            drawingColorScheme.Add("miss", Color.Brown);



            

        }
        
        public void BackgroundColorChanger()
        {
            Console.BackgroundColor = consoleColorScheme["back"];
        }
        public void ForegroundColorChanger()
        {
            Console.ForegroundColor = consoleColorScheme["front"];
        }
        public void ConsoleColorReset()
        {
            Console.ResetColor();
        }
        protected void DisplayFrameTop(string title, int width)
        {
            Console.WriteLine("\u250f" + String.Concat(Enumerable.Repeat("\u2501", 20)) + "\u2513");
            int titleLenEven = title.Length % 2 == 0 ? title.Length : title.Length + ;
            Console.WriteLine('\u2503'.ToString() + new string(' ', (width - titleLenEven) / 2) + 
                                $"{title.ToUpper()}" + new string(' ', (width - titleLenEven) / 2) + "\u2513");
        }
        
        protected void DisplayFrameBottom(int width)
        {
            Console.WriteLine('\u2503'.ToString() + $"{String.Empty:width}" + "\u2513");
            Console.WriteLine("\u250f" + String.Concat(Enumerable.Repeat("\u2501", width - 2)) + "\u2513");
        }
        public string Menu(string title, string info, Dictionary<string,string> options)
        {
            var keyList = options.Keys.ToList();
            int selectedKeyNum = 0;
            string pointer = " >>>";
            string ifPointer;
            string optionDisplayed;
            ConsoleKey keyPressed = ConsoleKey.A;
            do
            {
                DisplayFrameTop(title, Console.WindowWidth);
                Console.WriteLine(info);
                for (int ctr = 0; ctr < keyList.Count; ctr++)
                {   
                    ifPointer = selectedKeyNum == ctr ? pointer : "    ";
                    optionDisplayed = options[keyList[ctr]];
                    Console.WriteLine($"{ifPointer} {optionDisplayed}");
                }
                DisplayRemainingScreenEmpty(keyList.Count, 5);
                DisplayFrameBottom(Console.WindowWidth);
                var pressedKey = Console.ReadKey().Key;
                if (pressedKey == ConsoleKey.UpArrow && selectedKeyNum > 0)
                {
                    selectedKeyNum--;
                }
                else if (pressedKey == ConsoleKey.DownArrow && selectedKeyNum < options.Count - 1)
                {
                    selectedKeyNum++;
                }
            } while (keyPressed != ConsoleKey.Enter);
            return keyList[selectedKeyNum];
        }
        public void SetConsoleDimensions(int width, int height)
        {
            Console.WindowHeight = width;
            Console.WindowWidth = height;
        }
        public void DisplayGameStatistics(Game currentGame)
        {
            DisplayFrameTop("game statistics", Console.WindowWidth);

        }
        public string GetStringData(string query, string dataName)
        {
            DisplayFrameTop($"{query}", Console.WindowWidth);
            DisplayHalfScreenEmpty();
            Console.WriteLine($"Please provide {dataName}");
            var result = Console.ReadLine();
            return result;
            
        }
        public int GetIntData(string query, string dataName, int[] rangeEnds)
        {
            while (true)
            {
                DisplayFrameTop($"{query}", Console.WindowWidth);
                DisplayHalfScreenEmpty();
                Console.WriteLine($"Please provide {dataName}");
                try
                {
                    var result = int.Parse(Console.ReadLine());
                    return result;
                }
                catch (FormatException e)
                {
                    DisplayErrorMessage("Please enter an integer!");
                }
            }
        }
        
        private void DisplayErrorMessage(string errorMessage)
        {
            Console.Clear();
            DisplayFrameTop("Invalid value", Console.WindowWidth);
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

        }
        public List<Ship> PutShipsOnBoard(string info, )
        {
            var keyList = options.Keys.ToList();
            int selectedKeyNum = 0;
            string pointer = " >>>";
            string ifPointer;
            string optionDisplayed;
            while (true)
            {
                DisplayFrameTop("Put ships on Your ocean", Console.WindowWidth);
                Console.WriteLine()
            }
        }
}