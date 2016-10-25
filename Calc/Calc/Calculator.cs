using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public interface ICalculator
    {
        double Sum(double x, double y);

        double? Divide(double x, double y);

        double Subtr(double x, double y);

        double Mult(double x, double y);

        double Exp(double x, double y);

        double? Fact(double x);

        double? Sqrt(double x);

        Operation[] GetOperations();
    }
    public class Calculator : ICalculator
    {
        public double Sum(double x, double y)
        {
            return x + y; 
        }
        public double? Divide(double x, double y)
        {
            if (y == 0)
            {
                return null;
            }
            return x/y;
        }

        public double Subtr(double x, double y)
        {
            return x - y;
        }

        public double Mult(double x, double y)
        {
            return x * y;
        }

        public double Exp(double x, double y)
        {
            return Math.Pow(x, y);
        }

        public double? Fact(double x)
        {
            if (x < 0) return null;
                double? result;
                if (x == 1 || x == 0)
                    return 1;
                result = Fact(x - 1) * x;
                return result;
            
        }

        public double? Sqrt(double x)
        {
            if (x < 0)
            {
                return null;
            }
            return Math.Sqrt(x);
        }

        public Operation[] GetOperations()
        {
            return new Operation[]
            {
                new Operation(){Name = "Sum", ParameterCount = 2},
                new Operation(){Name = "Divide", ParameterCount = 2},
                new Operation(){Name = "Subtr", ParameterCount = 2},
                new Operation(){Name = "Mult", ParameterCount = 2},
                new Operation(){Name = "Exp", ParameterCount = 2},
                new Operation(){Name = "Fact", ParameterCount = 1},
                new Operation(){Name = "Sqrt", ParameterCount = 1},
            };
        }
    }

    public class Operation
    {
        public string Name { get; set; } 
        public int ParameterCount { get; set; } 
        public override string ToString()
        {
            return Name;
        }
    }
}
