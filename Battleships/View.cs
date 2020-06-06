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
        public View() 
        {
            consoleColorScheme.Add("back", ConsoleColor.Blue);
            consoleColorScheme.Add("front", ConsoleColor.White);

            mainMenuOptions = new string[] 
            {
                "Resume Saved Game",
                "Start New Game",
                "Options",
                "Saved Scores",
                "Quit Game"
            };
            consoleWidth = Console.WindowWidth;


            

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
            Console.WriteLine('\u2503'.ToString() + new string(' ', (width - title.Length) / 2) + 
                                $"{title.ToUpper()}" + new string(' ', (width - title.Length) / 2) + "\u2513");
        }
        
        protected void DisplayFrameBottom(int width)
        {
            Console.WriteLine('\u2503'.ToString() + $"{String.Empty:width}" + "\u2513");
            Console.WriteLine("\u250f" + String.Concat(Enumerable.Repeat("\u2501", 20)) + "\u2513");
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
            
        }
        public string GetStringData(string query, string dataName)
        {
            DisplayFrameTop($"{query}", Console.WindowWidth);
            for (int ctr = 0; ctr < (Console.WindowHeight - 2) / 2; ctr++)
            {
                Console.WriteLine(" ");
            }
            Console.WriteLine($"Please provide {dataName}");
            var result = Console.ReadLine();
            return result;
            
        }
        public List<Ship> PutShipsOnBoard()
        {

        }
}