using System;


namespace BattleShips
{
    public class Menu
    {
        public View menuDisplay; 
        public string[] menuOptions;
        private string selectedChoice;
        

        public Menu()
        {

        }

        public string GetChoice()
        {
            userChoice = System.Console.ReadLine();
            this.selectedChoice = userChoice;
        }

    }
}