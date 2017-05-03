using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecEuler.Problems1_20
{
    class Problem006 : Problem
    {
        int SumSquare, SquareSum, Difference;

        public override string GetResultString()
        {
            return "Result: " + SquareSum + " - " + SumSquare + " = " + Difference;
        }

        public override void Run()
        {
            int sum1 = 0, sum2 = 0;
            for(int i = 1; i <= 100; i++)
            {
                sum1 += i * i;
                sum2 += i;
            }
            SumSquare = sum1;
            SquareSum = sum2 * sum2;
            Difference = SquareSum - SumSquare;
        }

        public override void Setup()
        {
        }
    }
}
