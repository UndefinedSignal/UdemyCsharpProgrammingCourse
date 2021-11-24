using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourseOOPChapter3
{
    partial class Hangman
    {
        IEnumerable<string> words;
        private string hiddenWord;
        private StringBuilder showedWord;
        private int lives;

        public string ShowWord()
        {
            return showedWord.ToString();
        }

        public Hangman(int lives = 5)
        {
            if(lives < 5 || lives > 8)
            {
                throw new ArgumentException("Number of allowed lives should be between 5 and 8");
            }

            this.lives = lives;

            words = System.IO.File.ReadAllLines("Handgman\\WordsStockRus.txt");
            GenerateHiddenWord();
        }
        
        private void GenerateHiddenWord()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int rndWord = rand.Next(0, words.Count());
            hiddenWord = words.ElementAt(rndWord);
            showedWord = new StringBuilder(hiddenWord);
            for(var i = 0; i < hiddenWord.Length; i++)
            {
                showedWord[i] = '_';
            }
            Console.WriteLine($"DEBUG: Hidden word is {hiddenWord}. ShowedWord is {showedWord.ToString()}");
        }

        public void TestShowContents()
        {
            foreach(var k in words)
            {
                Console.WriteLine($"{k}");
            }
        }

        private void CycledReplaceChar(char ch)
        {
            for(int i=0; i<hiddenWord.Length;i++)
            {
                if(hiddenWord[i] == ch)
                {
                    showedWord[i] = ch;
                }
            }
        }

        private handleState TryChar(char ch)
        {
            if (hiddenWord.Contains(ch))
            {
                CycledReplaceChar(ch);
                return handleState.CorrectChar;
            }
            return handleState.IncorrectChar;
        }

        public handleState Process(char ch)
        {
            if(TryChar(ch) == handleState.IncorrectChar)
            {
                lives--;
            }
            if (lives < 0)
            {
                return handleState.OutOfChances;
            }
            if(hiddenWord == showedWord.ToString())
            {
                return handleState.Winner;
            }
            return handleState.IncorrectChar;
        }
    }
}
