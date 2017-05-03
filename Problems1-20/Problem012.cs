using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjecEuler.Utilities;

namespace ProjecEuler.Problems1_20
{
    class Problem012 : Problem
    {
        PrimeFinder P = new PrimeFinder();

        int Result;

        public override void Setup()
        {

        }

        public override string GetResultString()
        {
            return Result.ToString();
        }

        public override void Run()
        {
            int lastAdd = 1;
            int currentNum = 1;
            while (GetNumberOfDivisors(Factorize(currentNum)) <= 500)
            {
                lastAdd++;
                currentNum += lastAdd;
            }
            Result = currentNum;
        }

        Dictionary<int, int> Factorize(int n)
        {
            Dictionary<int, int> ret = new Dictionary<int, int>();
            P.CalcPrimesUpToN((int)Math.Ceiling(Math.Sqrt(n)));
            for (int i = 0; i < P.Count; i++)
            {
                int p = P[i];
                if (p == 1)
                    continue;
                while (n % p == 0)
                {
                    if (ret.ContainsKey(p))
                        ret[p]++;
                    else
                        ret[p] = 1;
                    n /= p;
                }
            }
            return ret;
        }

        //including 1
        int GetNumberOfDivisors(Dictionary<int, int> factors)
        {
            int ret = 1;
            foreach (var v in factors.Values)
            {
                ret *= v + 1;
            }
            return ret;
        }
    }
}