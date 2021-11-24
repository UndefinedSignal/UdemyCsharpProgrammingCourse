using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourseOOPChapter3
{
    class NumbersGame
    {
        private int firstNumber;
        private int lastNumber;
        private int secretNumber;

        public void PlayerSetSecretNumber(int num)
        {
            SetSecretNumber(num);
        }

        public bool SetSecretNumber(int num)
        {
            try
            {
                secretNumber = num;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"Argument is not valid, must be integer. {ex.Message}");
                return false;
            }
            return true;
        }

        public bool PickNumber(int num)
        {
            if (num == secretNumber)
            {
                Console.WriteLine($"Congratulations! {num} is a correct number!");
                return true;
            }else if (num < secretNumber)
            {
                Console.WriteLine($"The secret number is larger than {num}.");
                return false;
            }
            else
            {
                Console.WriteLine($"The secret number is less than {num}.");
                return false;
            }
        }

        public void ShuffleGame(int num1, int num2)
        {
            try
            {
                firstNumber = num1;
                lastNumber = num2;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"One of input arguments is not valid, must be integer. {ex.Message}");
            }
            if (firstNumber > lastNumber)
            {
                firstNumber = num2;
                lastNumber = num1;
            }
            Random rnd = new Random();
            secretNumber = rnd.Next(firstNumber, lastNumber);
            Console.WriteLine($"Try to guess a number beign near {firstNumber} and {lastNumber}!");
            Console.WriteLine($"Debug message. Secret number is {secretNumber}.");
        }

        public bool AIPickNumber()
        {
            int temp = (lastNumber - firstNumber) / 2 + firstNumber;

            Console.WriteLine($"DEBUG: lastNumber: {lastNumber}, firstNumber: {firstNumber}.");

            if (temp < secretNumber)
            {
                Console.WriteLine($"The secret number is larger than {temp}.");
                firstNumber = temp;
                return false;
            }else if(temp > secretNumber)
            {
                Console.WriteLine($"The secret number is less than {temp}.");
                lastNumber = temp;
                return false;
            }
            Console.WriteLine($"Congratulations! {temp} is a correct number!");
            return true;
        }
    }
}
