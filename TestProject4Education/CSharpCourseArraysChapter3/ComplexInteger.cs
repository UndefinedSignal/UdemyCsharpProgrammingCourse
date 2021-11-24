using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourseOOPChapter3
{


    class Complex
    {
        public double real { get; private set; }
        public double imaginary { get; private set; }

        public Complex(double real, double imaginary)
        {
            try
            {
                this.real = real;
                this.imaginary = imaginary;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Complex Plus(Complex input)
        {
            return new Complex(this.real + input.real, this.imaginary + input.imaginary);
        }
        public Complex Minus(Complex input)
        {
            return new Complex(this.real - input.real, this.imaginary - input.imaginary);
        }
    }
}
