using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecEuler.Problems1_20
{
    class Problem005 : Problem
    {
        int Result;

        public override string GetResultString()
        {
            return Result.ToString();
        }

        public override void Run()
        {
            bool found = false;
            int n = 19;
            while(!found)
            {
                n++;
                if(isDivisibleByLessThenA(n, 21))
                {
                    Result = n;
                    found = true;
                }
            }
        }

        public override void Setup()
        {
        }

        bool isDivisibleByLessThenA(int n, int a)
        {
            for(int i = 1; i < a; i++)
            {
                if (n % i != 0)
                    return false;
            }
            return true;
        }
    }
}
