using CSharpCourseOOPChapter3;
using System;
using System.Collections.Generic;

namespace CSharpCourseArraysChapter3
{
    class Program
    {
        static void Main(string[] args)
        {
            HangmanGame();
        }

        static void HangmanGame()
        {
            Hangman game = new Hangman(5);
            Console.WriteLine("Welcome to the Hangman game X_X!");
            Console.WriteLine("Try to quess what a word is hidden behind \"_\"!");
            Console.WriteLine($"Current \"showed\" word is: {game.ShowWord()}!");
            while (true)
            {
                Console.Write("Pick a letter: ");
                char.TryParse(Console.ReadLine(), out char playerInput);

                Hangman.handleState state = game.Process(playerInput);

                if (state == Hangman.handleState.CorrectChar)
                {
                    Console.WriteLine("Correct char!");
                    Console.WriteLine($"Current \"showed\" word is: {game.ShowWord()}!");
                    continue;
                }else if(state == Hangman.handleState.OutOfChances)
                {
                    Console.WriteLine("Out of chances! You lose!");
                    break;
                }
                else if(state == Hangman.handleState.IncorrectChar)
                {
                    Console.WriteLine("Incorrect char, try another one!");
                    Console.WriteLine($"Current \"showed\" word is: {game.ShowWord()}!");
                    continue;
                }
                else if(state == Hangman.handleState.Winner)
                {
                    Console.WriteLine("Congratulations! You win the Hangman game!");
                    break;
                }
            }
            Console.ReadLine();
        }

        static void TicTacToe()
        {
            TicTacToe game = new TicTacToe();
            while (true)
            {
                //Console.Clear();
                game.Draw();
                Console.WriteLine($"Enter a 2 coordinates of a field like \"22\" or \"01\"");
                int.TryParse(Console.ReadLine(), out int playerInput1);
                int.TryParse(Console.ReadLine(), out int playerInput2);

                if (!game.SetPoint(playerInput1, playerInput2))
                {
                    Console.WriteLine("The point is already taken. Choose another!");
                    Console.ReadLine();
                    continue;
                }
                if (game.Step())
                {
                    Console.WriteLine("Congratulations!");
                    Console.ReadLine();
                    break;
                }
            }
        }

        static void TestGame()
        {
            int chances = 0;
            int limit = 5;
            NumbersGame game = new NumbersGame();
            Console.WriteLine("Welcome to the game!");
            Console.WriteLine("Who will try to guess a secret number?");
            Console.WriteLine("Type 0 to play againts AI");
            Console.WriteLine("Type 1 to play with AI");
            int.TryParse(Console.ReadLine(), out int gamemode);
            Console.Write("Enter the first number: ");
            int.TryParse(Console.ReadLine(), out int firstNumber);
            Console.Write("Enter the second number: ");
            int.TryParse(Console.ReadLine(), out int secondNumber);
            if (gamemode < 1)
            {
                game.ShuffleGame(firstNumber, secondNumber);

                while (true)
                {
                    chances++;
                    if (game.AIPickNumber())
                    {
                        Console.WriteLine("Correct!");
                        break;
                    }
                    if (chances >= limit)
                    {
                        Console.WriteLine("Out of limit attempts");
                        break;
                    }
                }

            }
            else
            {
                game.ShuffleGame(firstNumber, secondNumber);

                while (true)
                {
                    chances++;
                    int.TryParse(Console.ReadLine(), out int playerInput);
                    if (game.PickNumber(playerInput))
                    {
                        Console.WriteLine("Correct!");
                        break;
                    }
                    if (chances >= limit)
                    {
                        Console.WriteLine("Out of limit attempts");
                        break;
                    }
                }
            }
        }

        static void CompexClassTest()
        {
            /*
                * Разработать класс представляющий комплексное число. Класс должен содержать два свойства для представления вещестенной (double)
                * и мнимой части (double). Сделать так, чтобы создать экземпляр класса без передачи соответствующих аргументов было невозможно.
                * Создать два метода, реализующих сложение и вычитание двух комплексных чисел. Чтобы сложить два комплексных числа необходимо 
                * по отдельности сложить их вещественные и мнимые части.
                * То есть, предположим, что мы имеет два комплексных числа. У первого вещественная часть равна 1, мнимая 2. 
                * У второго вещественная часть равна 3, мнимая 1. Результатам будет комплексное число, где вещественная часть равна 1+3=4, а мнимая равна 2 + 1 = 3.
                * Операция вычитания работает по тому же принципу, что и сложение (ну, только вычитание).
            */
            Complex c1 = new Complex(1, 1);
            Complex c2 = new Complex(1, 2);

            Complex result = c1.Plus(c2);
            
            Console.WriteLine($"{result.real} {result.imaginary}");
        }
        static void MyStackTest()
        {
            MyStack<int> ms = new MyStack<int>();
            ms.Push(1);
            ms.Push(2);
            ms.Push(3);
            //ms.Push("qwerty");
            //ms.Push(false);
            ms.Push('a'); // converted to int
            //ms.Push(0.3);

            foreach(var item in ms)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();

            while(ms.Count != 0)
            {
                Console.WriteLine(ms.Peek());
                ms.Pop();
            }

            Console.WriteLine(ms.Peek()); // Trhow exception

            ms.Pop();

            Console.WriteLine(ms.Peek());

            ms.Push(3);
            ms.Push(4);
            ms.Push(5);

            Console.WriteLine(ms.Peek());
            Console.ReadLine();
        }

        static void InterfaceTest()
        {
            IBaseCollection collection = new BaseList(4);
            collection.Add(1);
            collection.Add(2);
        }

        static void PolymorphismTest()
        {
            Shapes[] shapes = new Shapes[2];
            shapes[0] = new Triangle(10, 20, 30);
            shapes[1] = new Rectangle(5, 10);

            foreach (Shapes shape in shapes)
            {
                shape.Draw();
                Console.WriteLine(shape.Perimeter());
            }

            Console.ReadLine();
        }

        static void InheritanceTest()
        {
            ModelXTeminal terminal1 = new ModelXTeminal("123");
            terminal1.Connect();

            Console.ReadLine();
        }

        static void RefSwapTest()
        {
            int a = 1;
            int b = 2;

            Swap(ref a, ref b);

            Console.WriteLine($"a={a}, b={b}");

            Console.ReadLine();

            List<int> list = new List<int>();
            AddNumbers(list);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        static void Swap(ref int a, ref int b)
        {
            Console.WriteLine($"Original a={a}, b={b}");

            int tmp = a;
            a = b;
            b = tmp;

            Console.WriteLine($"Swapped a={a}, b={b}");
        }

        static void AddNumbers(List<int> numbers)
        {
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
        }

        private static void ClassAndStructCopyTest()
        {
            TestRefStruct ts1 = new TestRefStruct(); 
            ts1.PointRef = new PointRef() {X = 1, Y = 2 };
            //ts1.PointRef.X = 1;
            //ts1.PointRef.Y = 2;

            TestRefStruct ts2 = ts1;

            Console.WriteLine($"ts1.PointRef.X={ts1.PointRef.X}, ts1.PointRef.Y={ts1.PointRef.Y}");
            Console.WriteLine($"ts2.PointRef.X={ts2.PointRef.X}, ts2.PointRef.Y={ts2.PointRef.Y}");

            ts2.PointRef.X = 42;
            ts2.PointRef.Y = 45;

            Console.WriteLine($"ts1.PointRef.X={ts1.PointRef.X}, ts1.PointRef.Y={ts1.PointRef.Y}");
            Console.WriteLine($"ts2.PointRef.X={ts2.PointRef.X}, ts2.PointRef.Y={ts2.PointRef.Y}");


            Console.ReadLine();

            PointVal a; // same as PointVal a = new PointVal();
            a.X = 3;
            a.Y = 5;

            PointVal b = a;
            b.X = 7;
            b.Y = 10;

            a.LogValues();
            b.LogValues();

            Console.WriteLine("After structs");

            PointRef c = new PointRef(); // Ref links to same memory heap
            c.X = 3;
            c.Y = 5;

            PointRef d = c;
            d.X = 7;
            d.Y = 10;

            c.LogValues();
            d.LogValues();
        }

        private void DivideTest()
        {
            Calc Calculator = new Calc();
            if (Calculator.TryDivide(10, 2, out double result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Failed to divide");
            }
        }
        private void CalcTest()
        {
            Calc Calculator = new Calc();
            double square1 = Calculator.CalcTriangleSquare(ab: 40.0, bc: 20.0, ac: 30.0); // named arguments
            double square2 = Calculator.CalcTriangleSquare(40.0, 20.0, 30);
        }

        private void RomanTest()
        {
            Console.WriteLine($"Type a Rome number:{Environment.NewLine}"
            + $"* I - 1{Environment.NewLine}"
            + $"* V - 5{Environment.NewLine}"
            + $"* X - 10{Environment.NewLine}"
            + $"* L - 50{Environment.NewLine}"
            + $"* C - 100{Environment.NewLine}"
            + $"* D - 500{Environment.NewLine}"
            + "* M - 1000");
            string msg = Console.ReadLine().ToUpper();
            Console.WriteLine($"Rome {msg} in Arabic was {RomanNumber.Parse(msg)}");
            Console.WriteLine($"Rome {msg} in Arabic was {RomanNumber.ParseReverse(msg)}");
        }
        /*
         * Написать функцию, которая принимает на вход строку - римское число, а возвращает это число в арабском виде.
         * Например, если передаём "XV" - должна вернуть 15, если передаём "IV" - должна вернуть 4.
         * Вот список римских символов и их отображение на арабские числа:
         * I - 1
         * V - 5
         * X - 10
         * L - 50
         * C - 100
         * D - 500
         * M - 1000
         * Варианты типа IIIV = 5-3 = 2 мы не рассматриваем. Хотя Римляне и пользовались иногда такими видами записей, но есть разная информация о приемлимости оных.
         * В нашем ДЗ такие варианты мы не рассматриваем. Вот выдержка из wiki:
         * "Необходимо отметить, что другие способы «вычитания» недопустимы; так, число 99 должно быть записано как XCIX, но не как IC."
         * Подсказка. Для решения надо реализовать два правила:
         * 
         * Правила записи чисел римскими цифрами:
         * - если большая цифра стоит перед меньшей, то они складываются (принцип сложения),
         * - если меньшая цифра стоит перед большей, то меньшая вычитается из большей (принцип вычитания).
         * Защиту от некорректного ввода реализовать по вашему желанию (можно не делать, но для тренировки всегда полезно).
        */
    }
}
