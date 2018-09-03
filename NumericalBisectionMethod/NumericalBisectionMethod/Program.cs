/// <summary>
///     Programmer : Jonas Smith
///     Date start : 8/29/18
///     Purpose    : Create program that uses bisectin method to find zero between points
/// </summary>
using System;

namespace NumericalBisectionMethod
{
    class Program
    {
        static  double start_X      = 0.5;
        static  double end_X        = 4.5;

        // Initial function f(x) = (x-2)^2 - ln(x) = 0; 
        static void Main()
        {
            DisplayHeader();

            // Pass checkSigns variable to the iterateset so that I can determine if the function has multiple x-intercepts
            IterateSet( CheckSigns(start_X, end_X) );
            Console.ReadLine();
        }

        static void IterateSet(bool iterateValue)
        {
            double startX = start_X;
            double endX   = end_X;

            double midPoint = 0;

            int iterations = CalculateIterations();

            if (iterateValue)
            {
                midPoint = (start_X + end_X) / 2;
                Console.WriteLine( ApproximateZero(startX,   midPoint, iterations));
                Console.WriteLine(ApproximateZero(midPoint, endX, iterations));
            }
            else
            {
                ApproximateZero(startX, endX, iterations);
            }
        }

        static double ApproximateZero(double start, double end, int iterations)
        {
            double midPoint = 0;

            for (int index = 0; index < iterations; index++)
            {
                midPoint = (start + end) / 2;

                double test2 = function(start);
                double test1 = function(midPoint);

                // Check sign of midpoint y value
                int startSign = Math.Sign(function(start));
                int mdPntSign = Math.Sign(function(midPoint));

                if(mdPntSign ==startSign)
                {
                    start = midPoint;
                }
                else
                {
                    end = midPoint;
                }

                DisplayInfo();
            }

            return midPoint;
        }

        static void DisplayHeader()
        {
            Console.WriteLine("Programmer : Jonas Smith");
            Console.WriteLine("Program    : Bissection Method - Numerical Analysis");
            Console.WriteLine();
            Console.WriteLine("  N   |                  |            |");
            Console.WriteLine("----- | ---------------- | ---------- |");
            // I love vanessa :) 
        }

        static void DisplayInfo()
        {

        }

        static int CalculateIterations()
        {
            return Convert.ToInt32(Math.Ceiling( 5 * Math.Log(10) / Math.Log(2)));
        }

        static bool CheckSigns(double start_X, double end_x)
        {
            bool returnValue = true;

            if (Math.Sign(start_X) != Math.Sign(end_X))
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
