using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourseOOPChapter3
{
    public class TicTacToe
    {
        private readonly char[] symbol = { '-', 'X', 'O' };

        private int[,] field;
        /*
         * { 0 0 0 }
         * { 0 0 0 }
         * { 0 0 0 }
        */


        private int _currentPlayer = 1;

        public int CurrentPlayer
        {
            get => _currentPlayer;
            set
            {
                _currentPlayer = value;
                if (_currentPlayer > 2)
                {
                    _currentPlayer = 1;
                }
                if (_currentPlayer < 1)
                {
                    _currentPlayer = 1;
                }
            }
        }

        public TicTacToe()
        {
            field = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }
        private string GetCurrentPlayer()
        {
            if(CurrentPlayer == 1)
            {
                return "X";
            }
            return "O";
        }

        private bool CheckWin(int result)
        {
            if (result == 1)
            {
                Console.WriteLine("X is a winner!");
                return true;
            }
            else if (result == 16)
            {
                Console.WriteLine("O is a winner!");
                return true;
            }
            return false;
        }

        private bool CheckLines()
        {
            int result = 0;

            for(int i=0; i < 3; i++)
            {
                result = field[i, 0];
                for (int j = 0; j < 3; j++)
                {
                    result *= field[i, j];
                }
                if (CheckWin(result))
                {
                    return true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                result = field[0, i];
                for (int j = 0; j < 3; j++)
                {
                    result *= field[j, i];
                }
                if (CheckWin(result))
                {
                    return true;
                }
            }
            if(CheckWin(field[0, 0] * field[1, 1] * field[2, 2]) || CheckWin(field[0, 2] * field[1, 1] * field[2, 0]))
            {
                return true;
            }
            return false;
        }

        public void Draw()
        {
            int temp = 0;
            int counter = 1;
            Console.WriteLine($"Player {GetCurrentPlayer()}'s Turn!");
            Console.WriteLine($"     0   1   2");
            Console.Write("0  ");
            foreach (var i in field)
            {
                if (temp < 3)
                {
                    Console.Write($"| {symbol[i]} ");
                }
                else{
                    Console.WriteLine("|");
                    Console.Write($"{counter}  | {symbol[i]} ");
                    temp = 0;
                    counter++;
                }
                temp++;
            }
            Console.WriteLine("|");
        }

        public bool SetPoint(int x, int y)
        {
            if(field[x, y] == 0)
            {
                field[x, y] = CurrentPlayer;
                return true;
            }
            return false;
        }

        public bool Step()
        {
            Draw();
            if (CheckLines())
            {
                return true;
            }
            CurrentPlayer = CurrentPlayer + 1;
            return false;
        }
    }
}
