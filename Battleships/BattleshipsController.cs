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
        public static int MISSAGAIN = 0;
        public static int MISSOK  = 1;
        public static int SHOTAGAIN = 2;
        public static int SHOTOK = 3;
        public static int SHOTSANKED = 4;
        public static int HEIGHT = 10;
        public static int WIDTH = 10;
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
            {"ocean_width", $"Set width of the player's ocean [8 - 20]. Current {WIDTH}"},
            {"ocean_height", $"Set width of the player's ocean [8 - 20]. Current {HEIGHT}"},
            {"ships", "Add new ship type"},
            {"back", "Go back to main menu"}
        };
        private string settingsMenuInfo = "Select a setting to edit...";
        private string[] openingScreen;
        private View controllerDisplay = new View(WIDTH * 4 + 10,HEIGHT * 2 + 10);

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
                        OptionsSwitch();
                        break;
                    case "quit":
                        Environment.Exit(0);
                        break;
                }
            }
        }
        private void OptionsSwitch()
        {
            while (true)
            {
                
                string optionChoice = controllerDisplay.Menu("Options", settingsMenuInfo, settingsMenuOptions);
                switch (optionChoice)
                {
                    case "ocean_width":
                        int[] widthRange = new int[] {8, 20};
                        WIDTH = controllerDisplay.GetIntData("provide ocean's width","player's ocean's width", widthRange);
                        break;
                    case "ocean_height":
                        var heightRange = new int[] {8, 20};
                        HEIGHT = controllerDisplay.GetIntData("provide ocean's height","player's ocean's height", heightRange);
                        break;
                    case "ships":
                    var sizeRange = new int[] {1,6};
                        var newShipName = controllerDisplay.GetStringData(" provide new ship name", "new ship name");
                        var newShipSize = controllerDisplay.GetIntData("provide ship type size", "new ship type size", sizeRange);
                        shipsSizesAndNames.Add(newShipSize, newShipName);
                        break;
                    case "back":
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