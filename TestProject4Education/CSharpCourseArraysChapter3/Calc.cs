using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourseOOPChapter3
{
    class Calc
    {
        public double Avarage(int[] numbers)
        {
            int sum = 0;
            foreach(int n in numbers)
            {
                sum += n;
            }
            return (double)sum / numbers.Length;
        }

        public double Avarage2(params int[] numbers) // 1, 2, 3, 4 => { 1, 2, 3, 4 } params must be last arg
        {
            int sum = 0;
            foreach (int n in numbers)
            {
                sum += n;
            }
            return (double)sum / numbers.Length;
        }

        public double CalcTriangleSquare(double ab, double bc, double ac)
        {
            double p = (ab + bc + ac) / 2;
            return Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));
        }

        public double CalcTriangleSquare(double ab, double ac, int alpha, bool isInRadians = false) // isInRadians is optional param
        {
            if (isInRadians)
            {
                return 0.5 * ab * ac * Math.Sin(alpha);
            }
            else
            {
                double rads = alpha * Math.PI / 180;
                return 0.5 * ab * ac * Math.Sin(rads);
            }
        }

        public bool TryDivide(double divisible, double divisor, out double result)
        {
            result = 0;
            if (divisor == 0)
            {
                return false;
            }
            result = divisible / divisor;
            return true;
        }

        private void ParseInputValue()
        {
            string input = Console.ReadLine();
            bool wasParsed = int.TryParse(input, out int IntOut);
            if (wasParsed)
            {
                Console.WriteLine($"Our value was {IntOut}");
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }

    }
}
