using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecEuler.Problems1_20
{
    class Problem002 : Problem
    {
        int Result;

        public override string GetResultString()
        {
            return Result.ToString();
        }

        public override void Run()
        {
            int i = 1, j = 1, tmp;
            int result = 0;
            while(j <= 4000000)
            {
                if ((j & 1) == 0)
                    result += j;
                tmp = j;
                j = i + j;
                i = tmp;
            }
            Result = result;
        }

        public override void Setup()
        {
        }
    }
}
