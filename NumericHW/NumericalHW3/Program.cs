/// <summary>
///     Programmer :  Jonas Smith
///     Purpose    :  Use the three algorithms from the text found on page 213
/// </summary>

using System;
using System.Collections.Generic;

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
            Console.WriteLine("      the function value at P(4) = {0}", Function(4, 4));
            Console.WriteLine();
            Console.WriteLine("      the derivative value at P'(4) = {0}", Derivative(4, 4));
            Console.WriteLine();
            Console.WriteLine("  c)  the integral from 1 to 4 of f(x) = {0}", Integral(4,4, false) - Integral(1,4,false));
            Console.WriteLine();


            function = new double[4] { 2.08, -0.16, 0.14, -0.04 };
            Console.WriteLine("2)    For the function -0.04x^3 + 0.14x^2 - 0.16x + 2.08");
            Console.WriteLine();
            Console.WriteLine("      the function value at P(4) = {0}", Function(3, 4));
            Console.WriteLine();
            Console.WriteLine("      the function value at P'(4) = {0}", Derivative(3, 4));
            Console.WriteLine();
            Console.WriteLine("  c)  the integral from 0 to 3 of f(x) = {0}", Integral(3, 4, false) - Integral(0, 4, false));
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

                Console.WriteLine("{0}  b{1} ={2,5}", orderChar, --counter, returnValue);

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

                Console.WriteLine("{0}  d{1} ={2,5}", orderChar, --counter, returnValue);

                derivativeArray[i - 1] = returnValue;
            }

            Console.WriteLine();
            return returnValue;
        }

        static double Integral(double value, int iteration, bool write)
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

                if(write)
                    Console.WriteLine("{0}  i{1} ={2, 10: 0.000000}", orderChar, --counter, returnValue);

                integralArray[i - 1] = returnValue;
            }
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


/// <summary>
///     Console Output window
/// </summary>
//Programmer : Jonas Smith
// Assignment : Numerical Analysis Hw 3
// ------------------------------------
//1)    For the function -0.02x^3 + 0.1x^2 - 0.2x + 1.66

//  a)  b3 =-0.02
//      b2 = 0.02
//      b1 =-0.12
//      b0 = 1.18

//      the function value at P(4) = 1.18

//  b)  d2 =-0.06
//      d1 =-0.04
//      d0 =-0.36

//      the derivative value at P'(4) = -0.36

//  c)  the integral from 1 to 4 of f(x) = 4.305

//2)    For the function -0.04x^3 + 0.14x^2 - 0.16x + 2.08

//  a)  b3 =-0.04
//      b2 = 0.02
//      b1 = -0.1
//      b0 = 1.78

//      the function value at P(4) = 1.78

//  b)  d2 =-0.12
//      d1 =-0.08
//      d0 = -0.4

//      the function value at P'(4) = -0.4

//  c)  the integral from 0 to 3 of f(x) = 5.97
