/// <summary>
///     Programmer : Jonas Smith
///     Purpoese   : Write a program to approximate a derivative. 
/// </summary>

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NumericalHW5
{
    class NumericalHw5
    {
        static double x_not = (1 - Math.Sqrt(5)) / 3;
        static double node_Space_H = 0;
        static double function_Value;

        public static double function(double x_Input)
        {
            return Math.Sin(Math.Pow(x_Input, 3) - (7 * (Math.Pow(x_Input, 2))) + (6 * (x_Input)) + 8);
        }

        static void Main()
        {
            function_Value = function(x_not);

            PrintResults();
            Console.ReadLine();
        }

        static void PrintResults()
        {
            int index = 1;

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("  step  || Approximation by |    Errur using   || Approximation by |    Errur using   || Approximation by | Error using    ||");
            Console.WriteLine("  size  ||    formula (2)   |    formula (2)   ||    formula (3)   |    formula (3)   ||   formula (10)   | formula (10)   ||");
            Console.WriteLine("--------||------------------|------------------||------------------|------------------||------------------|----------------||");
            do
            {
                node_Space_H = Math.Pow(10, -index);

                Console.WriteLine("  10^-{0,-2}| {1,16} | {2,16} || {3, 16} | {4, 16} || {5, 16} | {6, 16} ||"
                                  , index
                                  , String.Format("{0:N13}", formula_Two(x_not))
                                  , String.Format("{0:N13}", formula_Two(x_not) - function_Value )
                                  , String.Format("{0:N13}", formula_Three(x_not))
                                  , String.Format("{0:N13}", formula_Three(x_not) - function_Value )
                                  , String.Format("{0:N13}", formula_Ten(x_not))
                                  , String.Format("{0:N13}", formula_Ten(x_not) - function_Value)
                                  );
                index++;
            }
            while (index <= 10);
        }

        static double formula_Two(double x_input)
        {
            return ( function(x_input - node_Space_H) 
                   - function(x_input)) 
                   / node_Space_H;
        }

        static double formula_Three(double x_input)
        {
            return ( function(x_input + node_Space_H) 
                   - function(x_input - node_Space_H)) 
                   / (2 * node_Space_H);
        }

        static double formula_Ten(double x_input)
        {
            return ( (-1) * function(x_input + 2 * node_Space_H) 
                      + 8 * function(x_input + node_Space_H) 
                      - 8 * function(x_input - node_Space_H) 
                      +     function(x_input - 2 * node_Space_H)) 
                      / (12 * node_Space_H);
        }
    }
}
