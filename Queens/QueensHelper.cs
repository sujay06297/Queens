using System;
using System.Collections.Generic;
using System.Text;

namespace Queens
{
    class QueensHelper
    {
        static int _maxQueens;
        static int[] _solutionsList;
        static int _solutionsCount = 0;

        public static void NQueens(int queensCount)
        {
            _maxQueens = queensCount;
            _solutionsList = new int[_maxQueens];
            QueensHelper.Check(0);
            Console.WriteLine($"一共有{_solutionsCount}種解法");
        }

        private static void Check(int n)
        {
            if (n == _maxQueens) 
            {
                Print();
                return;
            }

            for (int i = 0; i < _maxQueens; i++)
            {
                _solutionsList[n] = i;
                if (Judge(n))
                {
                    Check(n + 1);
                }
            }
        }

        private static bool Judge(int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (_solutionsList[i] == _solutionsList[n] || Math.Abs(n - i) == Math.Abs(_solutionsList[n] - _solutionsList[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private static void Print()
        {
            _solutionsCount++;
            var strBuilder = new StringBuilder();
            strBuilder.Append($"// Solution {_solutionsCount}");
            for (int i = 0; i < _solutionsList.Length; i++)
            {
                strBuilder.Append(System.Environment.NewLine);
                for (var j = 0; j < _maxQueens; j++)
                {
                    if (j == _solutionsList[i])
                    {
                        strBuilder.Append("Q");
                    }
                    else
                    {
                        strBuilder.Append(".");
                    }
                }
            }
            System.Console.WriteLine(strBuilder);
        }
    }
}
