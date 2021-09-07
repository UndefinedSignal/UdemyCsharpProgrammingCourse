using System;

namespace TestProject4Education
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        
        static void UserProfile()
        {
            /*
             * Запросить у пользователя: фамилию, имя, возраст, вес, рост.
             * 
             * Высчитать ИМТ (индекс массы тела) по формуле ИМТ = вес (кг) / (рост (м) * рост (м))
             * 
             * Сформировать единую строку, в следующем формате:
             * 
             * Your profile:
             * Full Name: фамилия, имя
             * Age: возраст
             * Weight: вес
             * Height: рост
             * Body Mass Index: ИМТ
             * 
             * Вывести сформированную строку на консоль.
            */
            string firstname, surname;
            int age;
            double weight, height, IMT;
            Console.WriteLine("Fill up your parameters");

            Console.Write("Firstname: ");
            firstname = Console.ReadLine();
            Console.Write("Surname: ");
            surname = Console.ReadLine();
            Console.Write("Age (years): ");
            age = int.Parse(Console.ReadLine());
            Console.Write("Weight (kg): ");
            weight = int.Parse(Console.ReadLine().Replace(".", ","));
            Console.Write("Height (m): ");
            height = double.Parse(Console.ReadLine().Replace(".", ","));

            Console.Clear();

            IMT = weight / Math.Pow(height,2);
            string output = $"Your profile:{Environment.NewLine}"
                        + $"Full Name: {string.Join(" ", firstname, surname)}{Environment.NewLine}"
                        + $"Age: {age}{Environment.NewLine}"
                        + $"Weight: {weight}{Environment.NewLine}"
                        + $"Height: {height}{Environment.NewLine}"
                        + $"Body Mass Index: {IMT}";
            Console.WriteLine(output);
            /* 
             * Your profile:
             * Full Name: Nik Tes
             * Age: 20
             * Weight: 80
             * Height: 1,78
             * Body Mass Index: 25,24933720489837
            */
        }

        static void GeronFormula()
        {
            /*
             * Запросить у пользователя длины трёх сторон треугольника. Длины могут быть представлены дробными значениями.
             * После получения длин сторон - использовать формулу Герона для вычисления площади треугольника.
             * Чтобы жизнь не казалась мёдом найдите формулу самостоятельно.
             * После вычисления площади - вывести результат на консоль.
            */
            string[] lines;
            string input;
            double a, b, c, p, S;

            Console.WriteLine("Введите длины трёх сторон треугольника, значения разделять через пробел:");
            input = Console.ReadLine().Replace(".",",");
            lines = input.Split(" ");
            Console.WriteLine($"{lines[0]},{lines[1]},{lines[2]}");
            a = double.Parse(lines[0]);
            b = double.Parse(lines[1]);
            c = double.Parse(lines[2]);
            p = (a + b + c) / 2;

            S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine("Площадь треугольника, по формуле Герона, со сторонами [{0} {1} {2}] равна {3}",a,b,c,S);
            /*
             * Введите длины трёх сторон треугольника, значения разделять через пробел:
             * 2.3 5.4 5.8
             * 2,3,5,4,5,8
             * Площадь треугольника, по формуле Герона, со сторонами [2,3 5,4 5,8] равна 6,206697491420054
            */
        }

        static void GetAIntAndShowItLength()
        {
            // 3. Запросить у пользователя целое число. Вывести количество цифр числа. Например, в числе 156 - 3 цифры.

            Console.Write("Введите целое число: ");
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(input.ToString().Length);
        }
        static void GetTwoIntAndSwapThem()
        {
            /*
             * 2. Запросить у пользователя два целых числа и сохранить в двух переменных. Вывести значения.
             *   Обменять значения переменных: например, если в переменной x было записано число 3, а в y число 5,
             *   сделать так, чтобы в y стало 3, а в x стало 5.
             *   Вывести значения после обмена.
            */
            string[] lines;

            Console.WriteLine("Введите 2 целых числа через пробел");

            string line = Console.ReadLine();
            lines = line.Split(" ");

            if (lines.Length == 2)
            {
                int number1 = int.Parse(lines[0]);
                int number2 = int.Parse(lines[1]);
                Console.WriteLine("Первое число {0}, второе число {1}", number1, number2);
                number1 = number1 + number2;
                number2 = number1 - number2;
                number1 = number1 - number2;
                Console.WriteLine("Первое число {0}, второе число {1}", number1, number2);
            }
            else
            {
                Console.WriteLine("Ошибка ввода, исполнение программы будет завершено");
                Console.ReadLine();
            }
        }
        static void TypeANameAndShowIt()
        {
            /*
             * 1. Запросить имя пользователя. Вывести Hello, [имя пользователя].
            */
            Console.WriteLine("Type your name");
            string username = Console.ReadLine();
            Console.WriteLine("Hello, {0}", username);
            Console.ReadLine();
        }
    }
}
