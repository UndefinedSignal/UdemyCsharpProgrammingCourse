using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourseOOPChapter3
{
    class RomanNumber
    {
        private static Dictionary<char, int> RomeDict = new Dictionary<char, int>()
            {
                {'I', 1 },
                {'V', 5 },
                {'X', 10 },
                {'L', 50 },
                {'C', 100 },
                {'D', 500 },
                {'M', 1000 }
            };

        static public int ParseReverse(string inpStr) // Incorrect work
        {
            int outNum = 0;

            for (int i = inpStr.Length - 1; i >= 0; i--)
            {
                if (!(i - 1 < 0) && RomeDict[inpStr[i - 1]] < RomeDict[inpStr[i]])
                {
                    outNum += RomeDict[inpStr[i]] - RomeDict[inpStr[i - 1]];
                    i--;
                }
                else if (!(i - 1 < 0) && RomeDict[inpStr[i - 1]] > RomeDict[inpStr[i]])
                {
                    outNum += RomeDict[inpStr[i]] + RomeDict[inpStr[i - 1]];
                    i--;
                }
                else
                {
                    outNum += RomeDict[inpStr[i]];
                }
            }
            return outNum;
        }

        static public int Parse(string inpStr)
        {
            int outNum = 0;

            for (int i = 0; i < inpStr.Length; i++)
            {
                if(i+1 < inpStr.Length && IsSubtractive(inpStr[i],inpStr[i+1]))
                {
                    outNum -= RomeDict[inpStr[i]];
                }
                else
                {
                    outNum += RomeDict[inpStr[i]];
                }
            }
            return outNum;
        }

        private static bool IsSubtractive(char c1, char c2)
        {
            return RomeDict[c1] < RomeDict[c2];
        }
    }
}
