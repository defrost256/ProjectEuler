using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecEuler
{
    abstract class Problem
    {
        public abstract void Setup();
        public abstract void Run();
        public abstract string GetResultString();
    }
}
