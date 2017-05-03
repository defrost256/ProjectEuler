using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecEuler.Problems1_20
{
    class Problem004 : Problem
    {
        int Pal, Q1, Q2;

        public override string GetResultString()
        {
            return "Result: " + Pal + " = " + Q1 + " * " + Q2;
        }

        public override void Run()
        {
            int pal = 0;
            for (int q1 = 999; q1 >= 1; q1--)
            {
                for (int q2 = q1; q2 >= 1; q2--)
                {
                    pal = q1 * q2;
                    if(pal > Pal && IsPalindrome(pal))
                    {
                        Pal = pal;
                        Q1 = q1;
                        Q2 = q2;
                    }
                }
            }
        }

        public override void Setup()
        {
        }

        bool IsPalindrome(int n)
        {
            string nStr = n.ToString();
            int l = nStr.Length;
            for(int i = 0; i < l/2; i++)
            {
                if (nStr[i] != nStr[l - i - 1])
                    return false;
            }
            return true;
        }
    }
}
