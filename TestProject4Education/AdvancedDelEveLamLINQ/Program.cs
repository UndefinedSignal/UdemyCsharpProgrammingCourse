using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;

namespace AdvancedDelEveLamLINQ
{
    public class CarArgs : EventArgs
    {
        public CarArgs(int currentSpeed)
        {
            CurrentSpeed = currentSpeed;
        }
        public int CurrentSpeed { get; }
    }

    public class Car
    {
        int speed = 0;

        public event EventHandler<CarArgs> TooFastDriving;
        //public event Action<object, int> TooFastDriving;

        //public delegate void TooFast(int currentSpeed);

        //private TooFast tooFast;

        public void Start()
        {
            speed = 10;
        }

        public void Accelerate()
        {
            speed += 10;

            if(speed > 80)
            {
                if(TooFastDriving!=null)
                    TooFastDriving(this, new CarArgs(speed));
            }
        }

        public void Stop()
        {
            speed = 0;
        }

        //public void RegisteOnTooFast(TooFast tooFast)
        //{
        //    this.tooFast += tooFast;
        //}

        //public void UnregisterOnTooFast(TooFast tooFast)
        //{
        //    this.tooFast -= tooFast;
        //}

    }

    partial class Program
    {

        static void Main(string[] args)
        {
            Quizz game = new Quizz();
            game.Start();

        }

        static void CsvRussianChessPlayersByAge(string file)
        {
            IEnumerable<ChessPlayer> list = File.ReadAllLines(file)
                .Skip(1)
                .Select(ChessPlayer.ParseFileCsv)
                .Where(Player => Player.Country == "RUS" && Player.Rating >= 2700)
                .OrderBy(Player => Player.BirthYear).ToList();

            foreach(var item in list)
            {
                Console.WriteLine($"{item.FirstName + " " + item.LastName} - {item.BirthYear}");
            }
        }

        static void MinMaxSumAvarage(string file)
        {
            IEnumerable<ChessPlayer> list = File.ReadAllLines(file)
                                        .Skip(1)
                                        .Select(ChessPlayer.ParseFileCsv)
                                        .Where(player => player.BirthYear > 1988)
                                        .OrderByDescending(player => player.Rating)
                                        .Take(10);

            Console.WriteLine($"The lowest rating in TOP 10: {list.Min(x => x.Rating)}");
            Console.WriteLine($"The highest rating in TOP 10: {list.Max(x => x.Rating)}");
            Console.WriteLine($"The avarage rating in TOP 10: {list.Average(x => x.Rating)}");
        }


        private static void DisplayLargestFilesWithounLINQ(string pathToDir)
        {
            var dirInfo = new DirectoryInfo(pathToDir);
            FileInfo[] files = dirInfo.GetFiles();
            Array.Sort(files, FilesComparison);

            for(int i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name} weights {file.Length}");
            }

        }

        private static void DisplayLargetsFilesWithLINQ(string pathToDir)
        {
            new DirectoryInfo(pathToDir)
                .GetFiles()
                //.OrderBy(KeySelector)
                .OrderByDescending(file => file.Length)
                .Take(5)
                .ForEach(file => Console.WriteLine($"{file.Name} with {file.Length}"));
        }



 //       static long KeySelector(FileInfo file)
 //       {
 //           return file.Length;
 //       }

        static int FilesComparison(FileInfo x, FileInfo y)
        {
            if (x.Length == y.Length) return 0;
            if (x.Length > y.Length) return -1;
            return 1;
        }

        private static void PlaySticksGame()
        {
            SticksGame game = new SticksGame(10, SticksGame.Player.Human);
            game.MachinePLayed += Game_MachinePLayed;
            game.HumanTurnToMakeMove += Game_HumanTurnToMakeMove;
            game.EndOfGame += Game_EndOfGame;
            game.Start();
        }

        private static void Game_EndOfGame(SticksGame.Player player)
        {
            Console.WriteLine($"Winner:{player}");
        }

        private static void Game_HumanTurnToMakeMove(object sender, int remainingSticks)
        {
            Console.WriteLine($"Remaining sticks:{remainingSticks}");
            Console.WriteLine("Take some sticks");

            bool takenCorrectly = false;
            while (!takenCorrectly)
            {
                if(int.TryParse(Console.ReadLine(), out int takenSticks))
                {
                    var game = (SticksGame)sender;

                    try
                    {
                        game.HumanTakes(takenSticks);
                        takenCorrectly = true;
                    }
                    catch(ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private static void Game_MachinePLayed(int sticksTaken)
        {
            Console.WriteLine($"Machine took:{sticksTaken}");
        }

        static void Test()
        {
            Timer timer = new Timer();
            timer.Elapsed += Timer_Elapsed;

            timer.Interval = 5000;

            timer.Start();

            Console.ReadLine();

            Car car = new Car();
            car.TooFastDriving += HandleOnTooFast;
            car.TooFastDriving += HandleOnTooFast; //x2

            car.TooFastDriving -= HandleOnTooFast;

            car.Start();

            for (int i = 0; i < 10; i++)
            {
                car.Accelerate();
            }
            car.Accelerate();
            car.Accelerate();
            car.Accelerate();

            Console.ReadLine();

        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Handling Timer Elapsed Event");
        }

        private static void HandleOnTooFast(object obj, CarArgs speed)
        {
            var car = (Car)obj;
            Console.WriteLine($"Oh, I got it, calling Stop()! Current Speed={speed.CurrentSpeed}");
            car.Stop();
        }

    }
}
