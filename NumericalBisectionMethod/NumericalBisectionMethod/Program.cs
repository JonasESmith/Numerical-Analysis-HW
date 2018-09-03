
using System;
/// <summary>
///     Programmer : Jonas Smith
///     Date start : 8/29/18
///     Purpose    : Create program that uses bisectin method to find zero between points
/// </summary>
namespace NumericalBisectionMethod
{
    class Program
    {
        static double start_X = 0.5;
        static double end_X = 4.5;

        static double iterations = 15;

        // Initial function f(x) = (x-2)^2 - ln(x) = 0; 
        static void Main(string[] args)
        {
            bool iterateValue = CheckSigns(start_X, end_X);
            IterateSet(iterateValue);
        }

        static void IterateSet(bool iterateValue)
        {
            double mindPoint = 0;

            if(iterateValue)
            {

                for (int index = 0; index < iterations; index++)
                {
                    mindPoint = (start_X + end_X) / 2;
                    if (function(mindPoint) > function(start_X))
                    {

                    }
                    else
                    {
                        end_X = mindPoint;
                    }
                    // if (pointOne is negative then we need to take numbers to the right or left)
                }
            }
        }

        static bool CheckSigns(double start_X, double end_x)
        {
            bool returnValue = true;

            if(Math.Sign(start_X) != Math.Sign(end_X))
            {
                returnValue = false;
            }
            return returnValue;
        }

        static double function(double xValue)
        {
            double yValue = Math.Pow((xValue - 2), 2) - Math.Log(xValue);

            return yValue;
        }
    }
}
