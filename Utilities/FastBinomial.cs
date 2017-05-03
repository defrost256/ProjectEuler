using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecEuler.Utilities
{
    class FastBinomial
    {
        List<List<int>> PascalsTriangle = new List<List<int>>();

        public FastBinomial()
        {
            List<int> row0 = new List<int>();
            row0.Add(1);
            List<int> row1 = new List<int>();
            row1.Add(1);
            row1.Add(1);
            PascalsTriangle.Add(row0);
            PascalsTriangle.Add(row1);
        }

        int GetBinomial(int n, int k)
        {
            if (n >= PascalsTriangle.Count)
                BuildPascalsTriangleToRowN(n);
            if (k > PascalsTriangle.Last().Count)
                return 0;
            return PascalsTriangle[n][k];
        }

        void BuildPascalsTriangleToRowN(int n)
        {
            while (PascalsTriangle.Count <= n)
            {
                List<int> lastRow = PascalsTriangle.Last();
                List<int> newRow = new List<int>();
                int newSize = lastRow.Count + 1;
                for (int i = 0; i < newSize; i++)
                {
                    if (i == 0)
                        newRow.Add(1);
                    else if (i == newSize - 1)
                        newRow.Add(1);
                    else
                        newRow.Add(lastRow[i - 1] + lastRow[i]);
                }
                PascalsTriangle.Add(newRow);
            }
        }
    }
}
