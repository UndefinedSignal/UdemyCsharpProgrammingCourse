using System;
using static AdvancedDelEveLamLINQ.Program;

namespace AdvancedDelEveLamLINQ
{
    partial class Quizz
    {
        public string question { get; private set; }
        public string answer { get; private set; }
        public string explanation { get; private set; }
        public int limit = 3;
        private int attempt = 0;
        public QuizzStatus gameStatus { get; private set; }

        public override string ToString()
        {
            return $"For the question: {question}, the answer was {answer}, because of {explanation}";
        }

        public Quizz()
        {
            
        }

        public void Start()
        {
            ParseCsvLine(@"E:\Coriolis\Dev\Git\UdemyCsharpProgrammingCourse\TestProject4Education\AdvancedDelEveLamLINQ\Questions.csv");
            if (gameStatus == QuizzStatus.InProgress)
            {
                attempt = 0;
            }
            if(gameStatus == QuizzStatus.InProgress)
            {
                throw new InvalidOperationException("Can't call Start when game is already in progress");
            }
            gameStatus = QuizzStatus.InProgress;

            while(gameStatus == QuizzStatus.InProgress)
            {
                if(attempt < limit)
                {
                    HumanTryToGuess();
                }

                EndOfGameCheck();
            }
        }

        private void HumanTryToGuess()
        {
            char.TryParse(Console.ReadLine(), out char playerInput);
            string planswer = playerInput.ToString().ToLower();
            if (answer == "Yes" && (planswer == "y" || planswer == "yes"))
            {
                Console.WriteLine("Yep!");
            }
            else if (answer == "No" && (planswer == "n" || planswer == "no"))
            {
                Console.WriteLine("Nope");
                attempt += 1;
            }
        }

        private void EndOfGameCheck()
        {
            if(attempt == limit)
            {
                gameStatus = QuizzStatus.GameEnded;
            }
        }

        public static Quizz ParseCsvLine(string line)
        {
            string[] parts = line.Split(";");
            return new Quizz()
            {
                question = parts[0],
                answer = parts[1],
                explanation = parts[2]
            };
        }
    }
}
