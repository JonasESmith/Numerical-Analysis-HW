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
        static double[,] points = new double[4, 2] 
                                        { { 1 ,1.54 }, 
                                          { 2, 1.5  }, 
                                          { 3, 1.42 }, 
                                          { 5, 0.66 } };

        static double[] function = new double[4] { 1.28, -0.4, 0.2, -0.02 }; //{ -0.02, 0.2, -0.4, 1.28 }
        // static double[] function = new double[4] { -0.02 ,  0.1 ,  -0.2 ,  1.66  };

    static void Main(string[] args)
        {
            Function(4, 4);
            Derivative(4, 4);
            Console.ReadLine();
        }

        static double Function(double inputValue, int iteration)
        {
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
                    returnValue = Math.Round(function[i - 1] + functionList[i] * inputValue, 3);
                }

                Console.WriteLine(returnValue);

                functionList[i - 1] = returnValue;
            }

            return returnValue;
        }

        static double Derivative(double value, int iteration)
        {
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
                    returnValue = Math.Round(i * function[i] + derivativeArray[i] * value, 3);
                }

                Console.WriteLine(returnValue);

                derivativeArray[i - 1] = returnValue;
            }

            return returnValue;
        }

        static double Integral(double value)
        {
            double returnValue = 0.00;

            return returnValue;
        }
    }
}
