using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public interface ICalculator
    {
        int Sum(int x, int y);

        int? Divide(int x, int y);
    }
    public class Calculator : ICalculator
    {
        public int Sum(int x, int y)
        {
            return x+y; 
        }
        public int? Divide(int x, int y)
        {
            if (y == 0)
            {
                return null;
            }
            return x / y;
        }

        public string[] Methods()
        {
            return new[] { "Sum", "Divide" };
        }
    }

}
