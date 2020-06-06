using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleShips
{
    class BattleshipsController
    {
        private static Dictionary<string,string> mainMenuOptions = new Dictionary<string, string>
        {
            {"new_game", "Start new game"},
            {"options", "Game options"},
            {"quit", "Exit game"}
        };
        private static Dictionary<string, string> newGameMenu = new Dictionary<string, string>
        {
            {"pvp", "Player vs player"},
            {"pvc", "Player vs computer"},
            {"cvc", "Computer vs computer. Simulation"}
        }
        private static string mainMenuInfo = "Select an action. Move using arrows, confirm your selection by pressing Enter";
        private Dictionary<string,string> settingsMenuOptions = new Dictionary<string, string>
        {
            {"size", "Set size of the player board [5-20]"},
            {"ships", "Set numbers of particular ship sizes"},
            {"back", "Go back to main menu"}
        };
        private string settingsMenuInfo = "Select a setting to edit..."
        private string[] openingScreen;
        private View gameDisplay = new View(Console.WindowWidth,Console.WindowHeight);

        public BattleshipsController()
        {
            var shipsNamesAndSizes = new Dictionary<string, int>
            {
                {"carrier", 5},
                {"battleship", 4},
                {"cruiser", 3},
                {"submarine", 3},
                {"destroyer", 2}
            }
            while (true)
            {
                string menuChoice = gameDisplay.Menu("Main Menu", mainMenuInfo, mainMenuOptions);
                switch (menuChoice)
                {
                    case "new_game":
                        var players = new List<Player>();
                        players.Add(InitPlayer());
                        Game battleshipGame = new Game("pvp", players);
                        break;

                    case "options":
                    while (true)
                        gameDisplay.DisplayGameStatistics
                        string optionChoice = gameDisplay.Menu("Options", settingsMenuInfo, settingsMenuOptions);
                        switch (optionChoice)
                        {
                            case "size":
                                gameDisplay.


                        }
                        break;

                    case "quit":
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public Player InitPlayer()
        {
            
            var playerName = gameDisplay.GetStringData("Create New Player", "Player name");
            Player newPlayer = new Player(playerName);
            gameDisplay.Display
        }
    }
}