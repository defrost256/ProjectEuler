using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjecEuler.Utilities;

namespace ProjecEuler.Problems1_20
{
    //Assuming 775123 = Ceil(Sqrt(600851475143))
    class Problem003 : Problem
    {
        PrimeFinder P = new PrimeFinder();
        int Result;

        public override string GetResultString()
        {
            return Result.ToString();
        }

        public override void Run()
        {
            long n = 600851475143;
            P.CalcPrimesUpToN(775123);
            for(int i = 0; i < P.Count; i++)
            {
                if((P[i] < 775123) && (n % (long)P[i] == 0) && P[i] > Result)
                {
                    Result = P[i];
                }
            }
        }

        public override void Setup()
        {
        }
    }
}
