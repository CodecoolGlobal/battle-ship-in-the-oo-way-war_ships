using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleShips
{
    class BattleshipsController
    {
        public static Dictionary<int, string> shipsSizesAndNames= new Dictionary<int, string>
        {
            {5, "carrier"},
            {4, "battleship"},
            {3, "cruiser"},
            {3, "submarine"},
            {2, "destroyer"}
        };
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
            {"ocean_width", $"Set width of the player's ocean [8 - 20]. Current {Ocean.WIDTH}"},
            {"ocean_height", $"Set width of the player's ocean [8 - 20]. Current {Ocean.HEIGHT}"},
            {"ships", "Set numbers of particular ship sizes"},
            {"back", "Go back to main menu"}
        };
        private string settingsMenuInfo = "Select a setting to edit...";
        private string[] openingScreen;
        private View controllerDisplay = new View(Console.WindowWidth,Console.WindowHeight);

        public BattleshipsController()
        {
            while (true)
            {
                string menuChoice = controllerDisplay.Menu("Main Menu", mainMenuInfo, mainMenuOptions);
                switch (menuChoice)
                {
                    case "new_game":
                        var players = new List<Player>();
                        players.Add(InitPlayer());
                        Game battleshipGame = new Game("pvp", players);
                        break;

                    case "options":
                    while (true)
                        controllerDisplay.DisplayOptions;
                        string optionChoice = controllerDisplay.Menu("Options", settingsMenuInfo, settingsMenuOptions);
                        switch (optionChoice)
                        {
                            case "ocean_width":
                                controllerDisplay.


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
            
            var playerName = controllerDisplay.GetStringData("Create New Player", "Player name");
            Player newPlayer = new Player(playerName);
            controllerDisplay.Display
        }
    }
 
}