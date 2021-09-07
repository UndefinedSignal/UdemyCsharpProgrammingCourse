using System;

namespace CSharpCourseChapter2
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static void LoginAttempts()
        {
            /*
             * Предположим, что логин\пароль для входа в систему: johnsilver\qwerty.
             * Запросить у пользователя логин и пароль. Дать пользователю только три попытки для ввода корректной пары логин\пароль.
             * Если пользователь произвёл корректный ввод, вывести на консоль: "Enter the System" и прекратить запрос логина\пароля.
             * Если пользователь ошибся трижды - вывести "The number of available tries have been exceeded" и прекратить запрос пары логин\пароль.
            */

            string login = "johnsilver", password = "qwerty", tlogin, tpass;
            int attempts = 0;
            while(attempts != 3)
            {
                attempts++;
                Console.WriteLine("Enter your login and password");
                Console.Write("Login: ");
                tlogin = Console.ReadLine();
                Console.Write("Password: ");
                tpass = Console.ReadLine();
                Console.Clear();
                if (login == tlogin && password == tpass)
                {
                    Console.WriteLine("Enter the System");
                    break;
                }
            }
            if (attempts == 3)
            {
                Console.WriteLine("The number of available tries have been exceeded");
            }
        }

        static void Factorial()
        {
            /*
             * Факториалом числа является произведение этого числа на все предшествующие этому числу числа (кроме 0).
             * Факториал в математике записывается через восклицательный знак. Например 5! = 5*4*3*2*1 = 120.
             * Особые случаи: 0! = 1. 1! = 1.
             * Задача: запросить у пользователя число, факториал которого необходимо вычислить и произвести вычисление.
             * Затем вывести результат вычисления. Восклицательный знак запрашивать не надо, кроме того, в C# такой операции нет.
             * Для вычисления факториала надо производить перемножение.
            */
            Console.Write("Type a number for factorial calculation: ");
            long tempNum = 1;
            int FactNum = int.Parse(Console.ReadLine());
            if (FactNum == 0 || FactNum == 1)
            {
                Console.WriteLine($"Factorial of {FactNum} = 1");
                Console.ReadLine();
                return;
            }
            for(int i = 1; i <= FactNum; i++)
            {
                tempNum *= i;
            }
            Console.WriteLine(tempNum);
        }

        static void CalcOfAvarage()
        {
            /*
             * Запросить у пользователя не более 10 целых положительных чисел. Пользователь может прекратить приём чисел, введя 0.
             * После прекращения приёма целых чисел
             * (это происходит в случае если было введено 10 чисел, либо пользователь ввёл 0, чтобы не вводить все 10)
             * подсчитать среднее значение целых положительных чисел кратных трём и вывести на консоль.
            */
            int temp, count = 0;
            double sum = 0, sumCount = 0, mean;
            int[] inputNum = new int[10];
            Console.WriteLine("Enter 10 or less int numbers: ");
            while (count < 10)
            {
                inputNum[count] = int.Parse(Console.ReadLine());

                if(inputNum[count] == 0)
                {
                    break;
                }
                count++;
            }

            for(int i = 0; i < count; i++)
            {
                if (inputNum[i] % 3 == 0)
                {
                    sum = sum + inputNum[i];
                    sumCount++;
                }
            }
            mean = sum / sumCount;
            Console.WriteLine(mean);
        }

        static void Fibbo()
        {
            /*
             * Числа фибоначчи описываются следующей последовательностью: 1, 1, 2, 3, 5, 8, 13, 21...
             * Первые два числа - единицы. Все последующие числа вычисляются как сумма двух предыдущих.
             * Задание: запросить у пользователя кол-во чисел Фибоначчи, которое он хотел бы сгенерировать (вычислить), и,
             * собственно, произвести генерацию (вычисление). В процессе генерации записывать числа в массив.
             * После генерации вывести вычисленные числа.
            */
            int count, num1, num2, temp = 0;
            Console.WriteLine("Enter the depth of Fibbo calc");
            count = int.Parse(Console.ReadLine());
            Console.Write("The first number is: ");
            num1 = int.Parse(Console.ReadLine());
            Console.Write("Second number is: ");
            num2 = int.Parse(Console.ReadLine());
            Console.WriteLine();

            string[] steps = new string[count];

            for (int i = 0; i < count; i++)
            {
                temp = num1 + num2;
                steps[i] = $"{num1} | {num2} | Sum: {temp}";
                num1 = num2;
                num2 = temp;
            }
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"A {i+1}'s step is: {steps[i]}");
            }
            Console.WriteLine($"Final num is: {temp}");
        }

    }
}
