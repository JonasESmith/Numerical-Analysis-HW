/// <summary>
///     Programmer : Jonas Smith
///     Pupose     : Approximate integral using trapezoidal and simpsons rule. 
/// </summary>
using System;

namespace NumericalHW6
{
    class NumericalHW6
    {
        static int[]  subIntervals_M = new int[] { 2, 4, 8, 16, 32 };

        static double actual_Value = (Math.PI / 2) +( Math.Pow(Math.PI, 2) / 4) - 2;

        static void Main()
        {
            double upperBound     = Math.PI / 2;
            double lowerBound     = 0.0;
            double nodeSpacing_H  = 0.0;

            double trapezoidValue = 0;
            double simpsonsValue = 0;

            printHeaders();

            for (int index = 0; index < subIntervals_M.Length; index++)
            {
                nodeSpacing_H  = ( upperBound - lowerBound ) / subIntervals_M[index];
                trapezoidValue = TrapezoidalRule(nodeSpacing_H, lowerBound, upperBound, index);

                nodeSpacing_H = ( upperBound - lowerBound ) / ( subIntervals_M[index] * 2 );
                simpsonsValue = SimpsonsRule(nodeSpacing_H, lowerBound, upperBound, index);

                PrintResults(subIntervals_M[index], trapezoidValue, simpsonsValue, 123.00);
            }

            Console.ReadLine();
        }

        // function for both composite methods bellow. 
        static public double function(double x_value)
        {
            return ((Math.Pow(x_value, 2) + x_value + 1 ) * Math.Cos(x_value));
        }




        // Composite Trapezoidal Rule - Page 357 1c
        static public double TrapezoidalRule(double H, double lowerBound, double upperBound, int M)
        {
            return (H / 2) * ( function(lowerBound) + function(upperBound) )
                                    + TrapezoidalError(H, lowerBound, M);
        }

        static public double TrapezoidalError(double H, double lowerBound, int M) {
            double functionSummation = 0.0;

            for(int i = 1; i <= subIntervals_M[M] - 1; i++)
            {
                functionSummation += function(lowerBound + (i * H) );
            }

            return H * functionSummation;
        }




        // Composite Simpson's Rule - Page 359 4c
        static public double SimpsonsRule(double H, double lowerBound, double upperBound, int M)
        {
            return (H / 3) * (function(lowerBound) + function(upperBound))
                                    + SimpsonsError(H , lowerBound, M);
        }

        static public double SimpsonsError(double H,double lowerBound, int index)
        {
            double firstSummation  = 0.0;
            double secondSummation = 0.0;

            for(int i = 1; i <= subIntervals_M[index] - 1; i++)
            {
                firstSummation += function(lowerBound + ((2 * i) * H));
            }

            for(int i = 1; i <= subIntervals_M[index]; i++)
            {
                secondSummation += function(lowerBound + ((2 * i - 1) * H));
            }

            return (2 * H) / 3 * (firstSummation) + ((4 * H) / 3) * secondSummation;
        }


        static void printHeaders()
        {
            Console.WriteLine("|----|--------------|--------------|----------|");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|----|--------------|--------------|----------|");
        }

        // prints the results for the methods used above and each interval. 
        static public void PrintResults(int mSub_value, double trapezoidalValue, double simpsonsValue, double errorValue)
        {
            Console.WriteLine("|{0,3} | {1,12} | {2,12} | {3,8} |", mSub_value, String.Format("{0:N10}", trapezoidalValue), String.Format("{0:N10}", simpsonsValue), errorValue);
            // print results in the form of SubInterValM[i], Trapezoidal, Simpson's, Error. 
        }

    }
}
