﻿using CSharpCourseOOPChapter3;
using System;
using System.Collections.Generic;

namespace CSharpCourseArraysChapter3
{
    class Program
    {
        static void Main(string[] args)
        {

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
