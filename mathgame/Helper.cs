namespace mathgame{
    internal class Helper{
        internal static List<Game> games = new List<Game>();        
        internal static int[] GetDivisionNumbers(){
        var  random = new Random();
        int firstNumber = random.Next(1, 99);
        int secondNumber = random.Next(1, 99);
        var result = new int[2];
        while(firstNumber % secondNumber != 0){
            firstNumber = random.Next(1, 99);
            secondNumber = random.Next(1, 99);
        }
        result[0] = firstNumber;
        result[1] = secondNumber;
        return result;
}
        internal static void GetGames(){
            Console.Clear();
            Console.WriteLine("Game history");
            Console.WriteLine("--- --- --- --- --- --- --- --- ");
            foreach(var game in games)
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} pts");
                Console.WriteLine("--- --- --- --- --- --- --- --- ");
                Console.WriteLine("Press any key to return to menu");
                Console.ReadLine();
        }
        internal static void AddToHistory(int gameScore, GameType gameType){
            games.Add(new Game{
                    Date = DateTime.Now,
                    Score = gameScore,
                    Type = gameType
                    });
        }
    }
}
