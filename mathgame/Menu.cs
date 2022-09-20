namespace mathgame{ 
    internal class Menu{
        GameEngine gameEngine = new();
        internal void ShowMenu (string? name, DateTime date) {
            Console.WriteLine("--- --- --- --- --- --- --- --- ---");
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. This is your math game. \n");
            bool isGameOn = true;
            do{
                Console.Clear();
                Console.WriteLine(@$"What game would you like to play?
                A - Addition
                S - Subtraction
                M - Multiplication
                D - Division
                V - View Previous Games
                Q - Quit");
            Console.WriteLine("--- --- --- --- --- --- --- --- ---");
            var gameSelected = Console.ReadLine();
            switch(gameSelected.Trim().ToLower())
{
    case "a": 
            gameEngine.AdditionGame("Addition game");
            break;
    case "s":
            gameEngine.SubstractionGame("Substraction game");
            break;
    case "d":
            gameEngine.DivisionGame("Division game");
            break;
    case "m":
            gameEngine.MultiplicationGame("Multiplication game");
            break;
    case "v": 
            Helper.GetGames();
            break;

    case "q":
            Console.WriteLine("Goodbye");
            isGameOn = false;
            Environment.Exit(1);
            break;
    
    default:
        Console.WriteLine("Invalid Input");
        Environment.Exit(1);
        break;
}
}
while(isGameOn);
}
    }
}
