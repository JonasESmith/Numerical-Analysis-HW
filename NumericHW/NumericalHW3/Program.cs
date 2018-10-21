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

        static double[] function;

    static void Main(string[] args)
        {

            function = new double[4] { 1.66, -0.2, 0.1, -0.02 };
            Function(4, 4);
            Derivative(4, 4);
            Integral(4, 4);

            Console.WriteLine();
            Console.WriteLine();

            function = new double[4] { 2.08, -0.16, 0.14, -0.04 };
            Function(3, 4);
            Derivative(3, 4);
            Integral(3, 4);
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

        static double Integral(double value, int iteration)
        {
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
                    if(i < 2)
                    {
                        returnValue = integralArray[i] * value;
                    }
                    else
                    {
                        returnValue = function[i - 2] / (i - 1) + integralArray[i] * value;
                    }
                }

                Console.WriteLine(returnValue);

                integralArray[i - 1] = returnValue;
            }

            return returnValue;
        }
    }
}
