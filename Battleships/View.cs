using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleShips
{
    class View
    {
        private Dictionary<string,ConsoleColor> consoleColorScheme = new Dictionary<string, ConsoleColor>();
        private Dictionary<string, Color> drawingColorScheme = new Dictionary<string, Color>();
        private string[] mainMenuOptions;
        private string[] settingsMenuOptions;
        private int consoleWidth;
        public View() 
        {
            consoleColorScheme.Add("back", ConsoleColor.Blue);
            drawingColorScheme.Add();

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
        public void ConsoleColorReset()
        {
            Console.ResetColor();
        }
        public void DisplayFrameTop(string title, int width)
        {
            Console.WriteLine("\u250f" + String.Concat(Enumerable.Repeat("\u2501", 20)) + "\u2513");
            Console.WriteLine('\u2503'.ToString() + $"{title:width}" + "\u2513");
        }
        
        public string MainMenu()
        {
            
        }
        public void SetConsoleDimensions(int width, int height)
        {
            
        }
    }
}