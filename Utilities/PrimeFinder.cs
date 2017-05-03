using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjecEuler.Utilities
{
    class PrimeFinder
    {
        List<int> Primes = new List<int>();
        Random rnd = new Random();

        List<int> sieveList = new List<int>(new int[]{1, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 49, 53, 59});

        public int Count { get { return Primes.Count; } }
        public int this[int i] { get { return Primes[i]; } }

        public PrimeFinder()
        { 
            Primes.Add(2);
            Primes.Add(3);
            Primes.Add(5);
        }

        public bool IsProvenPrime(int n)
        {
            return Primes.Contains(n);
        }

        public void CalcPrimesUpToN(int n)
        {
            Dictionary<int, bool> PrimeTestList = new Dictionary<int, bool>();
            for (int w = 0; w <= n / 60; w++)
            {
                foreach (int s in sieveList)
                {
                    PrimeTestList[60 * w + s] = false;
                }
            }

            int a = 5;
            int[] testSeq = { 1, 13, 17, 29, 37, 41, 49, 53 };
            for (int x = 1; a <= n; x++)
            {
                for (int y = 1; a <= n; y += 2)
                {
                    a = 4 * x * x + y * y;
                    if (a > n)
                        break;
                    if (testSeq.Contains(a % 60))
                    {
                        if (PrimeTestList.ContainsKey(a))
                            PrimeTestList[a] = !PrimeTestList[a];
                        else
                            PrimeTestList[a] = true;
                    }
                }
                a = 4 * (x + 1) * (x + 1);
            }

            a = 5;
            testSeq = new int[] { 7, 19, 31, 43 };
            for (int x = 1; a <= n; x += 2)
            {
                for (int y = 2; a <= n; y += 2)
                {
                    a = 3 * x * x + y * y;
                    if (a > n)
                        break;
                    if (testSeq.Contains(a % 60))
                    {
                        if (PrimeTestList.ContainsKey(a))
                            PrimeTestList[a] = !PrimeTestList[a];
                        else
                            PrimeTestList[a] = true;
                    }
                }
                a = 12 * (x + 1) * (x + 1);
            }

            a = 11;
            testSeq = new int[] { 11, 23, 47, 59 };
            for (int x = 2; a <= n; x++)
            {
                for (int y = x - 1; y >= 1 && a <= n; y -= 2)
                {
                    a = 3 * x * x - y * y;
                    if (a > n)
                        break;
                    if (testSeq.Contains(a % 60))
                    {
                        if (PrimeTestList.ContainsKey(a))
                            PrimeTestList[a] = !PrimeTestList[a];
                        else
                            PrimeTestList[a] = true;
                    }
                }
                a = 3 * (x + 1) * (x + 1) - (x - 1) * (x - 1);
            }

            a = 1;
            int aSqr = 1;
            int c;
            for (int w = 0; aSqr <= n; w++)
            {
                foreach (int s in sieveList)
                {
                    a = 60 * w + s;
                    aSqr = a * a;
                    if (aSqr > n)
                        break;
                    if (n > 7 && PrimeTestList.ContainsKey(a) && PrimeTestList[a])
                    {
                        c = 1;
                        for (int w2 = 0; c <= n; w2++)
                        {
                            foreach (int s2 in sieveList)
                            {
                                c = aSqr * (60 * w2 + s2);
                                if (c > n)
                                    break;
                                PrimeTestList[c] = false;
                            }
                            c = aSqr * (60 * (w2 + 1) + sieveList[0]);
                        }
                    }
                }
                a = 60 * (w + 1) + sieveList[0];
            }

            foreach(var KvP in PrimeTestList)
            {
                if (KvP.Value)
                    Primes.Add(KvP.Key);
            }
        }

        public void CalcPrimesToNth(int n)
        {
            if (n < 55)
                CalcPrimesUpToN(281);
            else
            {
                double a = n * (Math.Log(n) + Math.Log(Math.Log(n)));
                CalcPrimesUpToN((int)Math.Ceiling(a));
            }
        }

        public void DoubleCheckPrimes()
        {
            Primes.RemoveAll(p => !DefinitePrimeTest(p));
        }

        private int getNextPrimeAfterN(int n)
        {
            if (n < 7)
            {
                switch (n)
                {
                    case 2:
                        return 3;
                    case 3:
                    case 4:
                        return 5;
                    case 5:
                    case 6:
                        return 7;
                    default:
                        return 2;
                }
            }
            n++;
            n = getNextPrimeCandidateIncludingN(n);
            while (!PrimeTest(n, 3))
            {
                n++;
                n = getNextPrimeCandidateIncludingN(n);
            }
            return n;
        }

        int getNextPrimeCandidateIncludingN(int n)
        {
            int nModTen = n % 10;
            if (nModTen == 0 || nModTen == 2 || nModTen == 6 || nModTen == 8)
                return n + 1;
            if (nModTen == 5)
                return n + 2;
            if (nModTen == 4)
                return n + 3;
            return n;
        }

        public bool PrimeTest(int n, int prec)
        {
            for (int i = 0; i < prec; i++)
            {
                int nMinusOne = n - 1;
                float sqrtNMinusOne = (float)Math.Sqrt(nMinusOne);
                int r = 0, tmpR = 0;
                int d = 0, tmpD;
                while (1 << tmpR < sqrtNMinusOne)
                {
                    if(nMinusOne % (1 << tmpR) == 0 && ((tmpD = (nMinusOne / (1 << tmpR))) & 1) == 1)
                    {
                        r = tmpR;
                        d = tmpD;
                    }
                    tmpR++;
                }
                int a = rnd.Next(2, (int)Math.Sqrt(n) + 1);
                BigInteger A = new BigInteger(a);
                int x = (int)(BigInteger.Pow(A, d) % n);
                if (x == 1 || x == nMinusOne)
                    continue;
                int j;
                for (j = 0; j < r - 1; j++)
                {
                    x = (x * x) % n;
                    if (x == 1)
                        return false;
                    if (x == nMinusOne)
                        break;
                }
                if (j == (r - 1))
                    return false;
            }
            return true;
        }

        public bool DefinitePrimeTest(int n)
        {
            if (n < Primes.Last())
                CalcPrimesUpToN(n);
            foreach(int p in Primes)
            {
                if (p > n)
                    return true;
                if ((n % p) == 0)
                    return false;
            }
            return true;
        }
    }
}
