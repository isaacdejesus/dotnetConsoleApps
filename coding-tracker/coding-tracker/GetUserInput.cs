using System.Globalization;
namespace coding_tracker
{
    internal class GetUserInput
    {
        internal void MainMenu()
        {
            bool closeApp = false;
            while (closeApp == false)
            {
                Console.WriteLine("\n\nMAIN MENU");
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("\nType 0 to close application");
                Console.WriteLine("Type 1 to View Record");
                Console.WriteLine("Type 2 to Add Record");
                Console.WriteLine("Type 3 to Delete Record");
                Console.WriteLine("Type 4 to Update Record");
                string commandInput = Console.ReadLine();
                while(string.IsNullOrEmpty(commandInput))
                {
                    Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.\n");
                    commandInput = Console.ReadLine();
                }
                switch (commandInput)
                {
                    case "0": 
                        closeApp = true;
                        Environment.Exit(0);
                        break;
                    case "1": 
                        //codingController.Get();
                        break;
                    case "2": 
                        //ProcessAdd();
                        break;
                    case "3":
                        //ProcessDelete();
                        break;
                    case "4":
                        //ProcessUpdate();
                        break;
                    case "5":
                        //ProcessReport();
                        break;
                    default: 
                        Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4 \n");
                        break;
                }
            }
        }
        private void ProcessAdd(){
            var date = GetDateInput();
            var duration = GetDurationInput();
        }
        internal string GetDateInput(){
            Console.WriteLine("\n\nPlease insert the date: (Format: dd-mm-yy). Type 0 to return to menu.\n\n");
            string dateInput = Console.ReadLine();
            if(dateInput == "0") MainMenu();
            while(!DateTime.TryParseExact(dateInput, "dd-MM-yy", new CultureInfo("en-US"), DateTimeStyles.None, out _))
            {
                Console.WriteLine("\n\nNot a valid date. Please insert date in format: dd-mm-yy.\n\n");
                dateInput = Console.ReadLine();
            }
            return dateInput;
        }
    }
}
