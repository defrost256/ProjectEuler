using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjecEuler.Utilities;

namespace ProjecEuler.Problems1_20
{
    class Problem007 : Problem
    {
        int Result;

        public override string GetResultString()
        {
            return Result.ToString();
        }

        public override void Run()
        {
            PrimeFinder p = new PrimeFinder();
            p.CalcPrimesToNth(10010);
            Result = p[10001];
        }

        public override void Setup()
        {
        }
    }
}
