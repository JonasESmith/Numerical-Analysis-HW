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

            // Pass checkSigns variable to the iterateset so that I can 
            // determine if the function has multiple x-intercepts
            IterateSet( CheckSigns(start_X, end_X) );
            Console.ReadLine();
        }

        static void IterateSet(bool iterateValue)
        {
            double startX = start_X;
            double endX   = end_X;

            double midPoint = 0;

            int iterations = CalculateIterations(startX, endX);

            if (iterateValue)
            {
                midPoint = (start_X + end_X) / 2;
                DisplayTop(startX, midPoint);
                ApproximateZero(startX,   midPoint, iterations);
                DisplayFooter();

                DisplayTop(midPoint, endX);
                ApproximateZero(midPoint, endX, iterations);
                DisplayFooter();
            }
            else
            {
                DisplayTop(startX, endX);
                ApproximateZero(startX, endX, iterations);
                DisplayFooter();
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

                DisplayInfo(index, midPoint, start, end);
            }

            return midPoint;
        }

        static void DisplayFooter()
        {
            Console.WriteLine(" ------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }

        static void DisplayTop(double start, double end)
        {
            Console.WriteLine("   N   |  X Value  |  Abs.Error  |  Rel.Error  |" +
                "         Domain");
            Console.WriteLine(" ----- | --------- | ----------- | ----------- |" +
                "    {0} <= x <= {1}", start, end);
        }

        static void DisplayHeader()
        {
            Console.WriteLine("Programmer  :  Jonas Smith");
            Console.WriteLine("Program     :  Bissection Method - Numerical Analysis");
            Console.WriteLine();
        }

        static void DisplayInfo(int index, double approximation, double start, double end)
        {
            Console.WriteLine(" {0,5} |  {1,7}  | {2,11} | {3,11} |", 
                                      index + 1, 
                                      Math.Round(approximation, 5).ToString("0.00000"), 
                                      Math.Round((end - start) / Math.Pow(2, index), 9), 
                                      (((end - start) / start)).ToString("0.00000000"));
        }

        static int CalculateIterations(double start, double end)
        {
            return Convert.ToInt32(Math.Ceiling( 5 * Math.Log((end - start) * 10) / Math.Log(2)));
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
