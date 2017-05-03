using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecEuler.Problems1_20
{
    class Problem001 : Problem
    {
        int Result;

        public override string GetResultString()
        {
            return Result.ToString();
        }

        public override void Run()
        {
            int result = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (i % 5 == 0 || i % 3 == 0)
                    result += i;
            }
            Result = result;
        }

        public override void Setup()
        {
        }
    }
}
