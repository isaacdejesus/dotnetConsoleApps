namespace mathgame {
    internal class GameEngine {
        internal void AdditionGame(string message){
            var random = new Random();
            int score = 0;
            int firstNumber;
            int secondNumber;
            for(int i = 0; i < 5; i++){
                Console.Clear();
                firstNumber = random.Next(1,9);
                secondNumber = random.Next(1,9);
                Console.WriteLine($"{firstNumber} + {secondNumber}");
                string result = Console.ReadLine();
                if(int.Parse(result) == firstNumber + secondNumber){
                    Console.WriteLine("Your answer was correct. Type any key for next question");
                    score++;
                    Console.ReadLine();
                }
                else{
                    Console.WriteLine("Incorrect. Type any key for next question");
                    Console.ReadLine();
                }
                if(i == 4)
                    Console.WriteLine($"Game over. Your final score is {score}");
            }
        Helper.AddToHistory(score, GameType.Addition);
        }
        internal void SubstractionGame(string message){
            var random = new Random();
            int score = 0;
            int firstNumber;
            int secondNumber;
            for(int i = 0; i < 5; i++){
                Console.Clear();
                firstNumber = random.Next(1,9);
                secondNumber = random.Next(1,9);
                Console.WriteLine($"{firstNumber} - {secondNumber}");
                string result = Console.ReadLine();
                if(int.Parse(result) == firstNumber - secondNumber){
                    Console.WriteLine("Your answer was correct. Type any key for next question");
                    score++;
                    Console.ReadLine();
                }
                else{
                    Console.WriteLine("Incorrect. Type any key for next question");
                    Console.ReadLine();
                }
                if(i == 4)
                    Console.WriteLine($"Game over. Your final score is {score}");
            }
        Helper.AddToHistory(score, GameType.Subtraction);
        }
        internal void MultiplicationGame(string message){
            var random = new Random();
            int score = 0;
            int firstNumber;
            int secondNumber;
            for(int i = 0; i < 5; i++){
                Console.Clear();
                firstNumber = random.Next(1,9);
                secondNumber = random.Next(1,9);
                Console.WriteLine($"{firstNumber} * {secondNumber}");
                string result = Console.ReadLine();
                if(int.Parse(result) == firstNumber * secondNumber){
                    Console.WriteLine("Your answer was correct. Type any key for next question");
                    score++;
                    Console.ReadLine();
                }
                else{
                    Console.WriteLine("Incorrect. Type any key for next question");
                    Console.ReadLine();
                }
                if(i == 4)
                    Console.WriteLine($"Game over. Your final score is {score}");
            }
        Helper.AddToHistory(score, GameType.Multiplication);
        }
        internal void DivisionGame(string message){
            int score = 0;
            for(int i = 0; i < 5; i++){
                Console.Clear();
                var divisionNumbers = Helper.GetDivisionNumbers();
                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];
                Console.WriteLine($"{firstNumber} / {secondNumber}");
                var result = Console.ReadLine();
                if(int.Parse(result) == firstNumber / secondNumber){
                    Console.WriteLine("Your answer was correct. Type any key for next question");
                    score++;
                    Console.ReadLine();
                }
                else{
                    Console.WriteLine("Incorrect. Type any key for next question");
                    Console.ReadLine();
                }
                if(i == 4){
                    Console.WriteLine($"Game over. Your final score is {score}. Press any key to return to main menu");
                    Console.ReadLine();
                }
            }
        Helper.AddToHistory(score, GameType.Division);
        }

    }
}
