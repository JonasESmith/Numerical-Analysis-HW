/// <summary>
///     Programmer :  Jonas Smith
///     Purpose    :  Use the three algorithms from the text found on page 213
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalHW3
{
    class Program
    {
        static List<double> functionList = new List<double>();

        static double[] function;

    static void Main(string[] args)
        {
            WriteHeader();

            function = new double[4] { 1.66, -0.2, 0.1, -0.02 };

            Console.WriteLine("1)    For the function -0.02x^3 + 0.1x^2 - 0.2x + 1.66");
            Console.WriteLine();    
            Console.WriteLine("      the function value at P(4) = {0}",Function(4, 4));
            Console.WriteLine();    
            Console.WriteLine("      the function value at P'(4) = {0}", Derivative(4, 4));
            Console.WriteLine();    
            Console.WriteLine("      the function value at I(4) = {0: 0.00000}", Integral(4, 4));
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("For the function -0.04x^3 + 0.14x^2 - 0.16x + 2.08");
            function = new double[4] { 2.08, -0.16, 0.14, -0.04 };
            Function(3, 4);
            Derivative(3, 4);
            Integral(3, 4);
            Console.ReadLine();
        }

        static double Function(double inputValue, int iteration)
        {

            string orderChar = "  a)";
            int counter = iteration;

            double[] functionList = new double[iteration];

            double returnValue = inputValue;

            for (int i = iteration; i > 0; i--)
            {
                if (i == iteration)
                {
                    returnValue = function[i - 1];
                }
                else
                {
                    orderChar = "    ";
                    returnValue = Math.Round(function[i - 1] + functionList[i] * inputValue, 3);
                }

                Console.WriteLine("{0}   b{1} ={2,5}" ,orderChar , --counter , returnValue);

                functionList[i - 1] = returnValue;
            }

            Console.WriteLine();
            return returnValue;
        }

        static double Derivative(double value, int iteration)
        {
            string orderChar = "  b)";
            int counter = iteration - 1;

            double returnValue = value;

            double[] derivativeArray = new double[iteration - 1];


            for (int i = iteration - 1; i > 0; i--)
            {
                if (i == (iteration - 1))
                {
                    returnValue = i * function[i];
                }
                else
                {
                    orderChar = "    ";
                    returnValue = Math.Round(i * function[i] + derivativeArray[i] * value, 3);
                }

                Console.WriteLine("{0}   d{1} ={2,5}", orderChar, --counter, returnValue);

                derivativeArray[i - 1] = returnValue;
            }

            Console.WriteLine();
            return returnValue;
        }

        static double Integral(double value, int iteration)
        {
            string orderChar = "  c)";
            int counter = iteration + 1;

            double returnValue = value;

            double[] integralArray = new double[iteration + 1];

            for (int i = iteration + 1; i > 0; i--)
            {
                if (i == (iteration + 1))
                {
                    returnValue = function[i - 2] / (i - 1);
                }
                else
                {
                    orderChar = "    ";
                    if (i < 2)
                    {
                        returnValue = integralArray[i] * value;
                    }
                    else
                    {
                        returnValue = function[i - 2] / (i - 1) + integralArray[i] * value;
                    }
                }

                Console.WriteLine("{0}   i{1} ={2, 10: 0.000000}", orderChar, --counter, returnValue);

                integralArray[i - 1] = returnValue;
            }

            Console.WriteLine();
            return returnValue;
        }

        public static void WriteHeader()
        {
            Console.WriteLine(" Programmer : Jonas Smith");
            Console.WriteLine(" Assignment : Numerical Analysis Hw 3");
            Console.WriteLine(" ------------------------------------");
        }
    }
}
