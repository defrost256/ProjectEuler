using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjecEuler.Utilities;
using ProjecEuler.Problems1_20;

using System.IO;

namespace ProjecEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problem P = new Problem007();
            //P.Setup();
            //P.Run();
            //Console.WriteLine(P.GetResultString());
            StreamReader r = new StreamReader(new FileStream("C:/"))
            PrimeFinder P = new PrimeFinder();
            P.CalcPrimesToNth(10010);
            int myPrime, realPrime;
            for(int i = 0; i < P.Count; i++)
            {
                myPrime = P[i];

            }
        }
    }
       
}
