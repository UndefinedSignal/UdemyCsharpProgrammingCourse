using System;

namespace TestProject4Education
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAIntAndShowItLength();

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
