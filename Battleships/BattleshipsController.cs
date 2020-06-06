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
        private Dictionary<string,string> settingsMenuOptions;
        private string[] openingScreen;
        private View gameDisplay = new View();

        public BattleshipsController()
        {
            string choice = gameDisplay.Menu("Main Menu", mainMenuInfo, mainMenuOptions);
            if (choice == "new_game")
            {

                Game battleshipGame = new Game();
            }
        }
        public Player InitPlayer()
        {
            View createPlayerScreen = new View();
            var playerName = createPlayerScreen.GetStringData("Create New Player", "Player name");
            Player newPlayer = new Player(playerName);
            createPlayerScreen.Display
        }
    }
}