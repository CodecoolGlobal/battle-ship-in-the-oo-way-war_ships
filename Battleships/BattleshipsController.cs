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
        private static string mainMenuInfo = "Select an action. Move using arrows, confirm your selection by pressing Enter";
        private Dictionary<string,string> settingsMenuOptions = new Dictionary<string, string>
        {
            {"size", "Set size of the player board [5-20]"},
            {"ships", "Set numbers of particular ship sizes"}
        };
        private string settingsMenuInfo = "Select a setting to edit..."
        private string[] openingScreen;
        private View gameDisplay = new View();

        public BattleshipsController()
        {
            while (true)
            {
                string choice = gameDisplay.Menu("Main Menu", mainMenuInfo, mainMenuOptions);
                if (choice == "new_game")
                {
                    var players = new List<Player>();
                    players.Add(InitPlayer());
                    Game battleshipGame = new Game("pvp", players);
                }
                else if (choice == "options")
                {
                    string optionChoice = gameDisplay.Menu("Options", settingsMenuInfo, settingsMenuOptions);
                }
                else if (choice == "quit")
                {
                    Environment.Exit(0);
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