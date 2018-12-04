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

                PrintResults(subIntervals_M[index], trapezoidValue, simpsonsValue);
            }

            printFooter();
            Console.ReadLine();
        }

        // function for both composite methods bellow. 
        static public double function(double x_value)
        {
            return ((Math.Pow(x_value, 2) + x_value + 1 ) * Math.Cos(x_value));
        }

        // Absolute error from the actual integral and the approximation
        static public double AbsoluteError(double approximation)
        {
            return Math.Abs(actual_Value - approximation);
        }




        // Composite Trapezoidal Rule - Page 357 1c
        static public double TrapezoidalRule(double H, double lowerBound, double upperBound, int M)
        {
            return (H / 2) * ( function(lowerBound) + function(upperBound) )
                                    + TrapezoidalSummation(H, lowerBound, M);
        }

        static public double TrapezoidalSummation(double H, double lowerBound, int M) {
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
                                    + SimpsonsSummation(H , lowerBound, M);
        }

        static public double SimpsonsSummation(double H,double lowerBound, int index)
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
            Console.WriteLine();
            Console.WriteLine("                       Programmer : Jonas Smith");
            Console.WriteLine();

            Console.WriteLine("  ________________________________________________________________ ");
            Console.WriteLine(" |     |              |              ||             |             |");
            Console.WriteLine(" |  M  |    T(f,h)    |    S(f,h)    ||  T() Error  |  S() Error  |");
            Console.WriteLine(" |-----|--------------|--------------||-------------|-------------|"); }
        static void printFooter()
        { Console.WriteLine(  " |_____|______________|______________||_____________|_____________|");
        }

        // prints the results for the methods used above and each interval. 
        static public void PrintResults(int mSub_value, double trapezoidalValue, double simpsonsValue)
        {
            Console.WriteLine(" |{0,3}  | {1,12} | {2,12} || {3,8} | {4,8} |", mSub_value, 
                String.Format("{0:N10}", trapezoidalValue), String.Format("{0:N10}", simpsonsValue), 
                String.Format("{0:N9}", AbsoluteError(trapezoidalValue)), String.Format("{0:N9}", 
                AbsoluteError(simpsonsValue)));
        }
    }
}

 // Console output for applicaiton
 //
 //                       Programmer : Jonas Smith
 // 
 //  ________________________________________________________________
 // |     |              |              ||             |             |
 // |  M  |    T(f,h)    |    S(f,h)    ||  T() Error  |  S() Error  |
 // |-----|--------------|--------------||-------------|-------------|
 // |  2  | 1.7268126568 | 2.0384413365 || 0.311384770 | 0.000243909 |
 // |  4  | 1.9605341666 | 2.0382138752 || 0.077663261 | 0.000016448 |
 // |  8  | 2.0187939481 | 2.0381984730 || 0.019403479 | 0.000001046 |
 // | 16  | 2.0333473418 | 2.0381974927 || 0.004850085 | 0.000000066 |
 // | 32  | 2.0369849550 | 2.0381974312 || 0.001212472 | 0.000000004 |
 // |_____|______________|______________||_____________|_____________|
