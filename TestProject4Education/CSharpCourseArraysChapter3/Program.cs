using CSharpCourseOOPChapter3;
using System;
using System.Collections.Generic;

namespace CSharpCourseArraysChapter3
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStackTest();
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
