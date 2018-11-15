/// <summary>
///     Programmer : Jonas Smith
///     Purpoese   : Write a program to approximate a derivative. 
/// </summary>

using System;

namespace NumericalHW5
{
    class NumericalHw5
    {
        static double x_not = (1 - Math.Sqrt(5)) / 3;
        static double function_Value;

        public static double function(double x_Input)
        {
            return Math.Sin(Math.Pow(x_Input, 3) - (7 * (Math.Pow(x_Input, 2))) + (6 * (x_Input)) + 8);
        }

        static double derivative_function(double x_Input)
        {
            return Math.Cos(Math.Pow(x_Input, 3) - (7 * (Math.Pow(x_Input, 2))) + (6 * (x_Input)) + 8) 
                                                * ( 3 * Math.Pow(x_Input, 2) - (14 * x_Input) + (6));
        }

        static void Main()
        {
            function_Value = derivative_function(x_not);

            PrintResults();
            Console.ReadLine();
        }


        static void PrintResults()
        {
            int index = 1;

            /// Prints headers for the applications
            Console.WriteLine("");
            Console.WriteLine("--------| |-------------------------------------| |-------------------------------------| |-------------------------------------||");
            Console.WriteLine("  step  | | Approximation by |    Error using   | | Approximation by |    Error using   | | Approximation by |   Error using    ||");
            Console.WriteLine("  size  | |    formula (2)   |    formula (2)   | |    formula (3)   |    formula (3)   | |   formula (10)   |   formula (10)   ||");
            Console.WriteLine("--------| |------------------|------------------| |------------------|------------------| |------------------|------------------||");

            /// Initialize all values used for finding optimal h value
            double node_Space_H = 0;

            double form_Two_Value = 0;
            double form_Thr_Value = 0;
            double form_Ten_Value = 0;

            double form_Two_error = 0;
            double form_Thr_error = 0;
            double form_Ten_error = 0;

            double last_form_Two_error = form_Two_error;
            double last_form_Thr_error = form_Thr_error;
            double last_form_Ten_error = form_Ten_error;

            bool form_Two = false;
            bool form_Thr = false;
            bool form_Ten = false;

            int form_Two_Optimal_H = 0;
            int form_Thr_Optimal_H = 0;
            int form_Ten_Optimal_H = 0;

            int continue_Iterating = 10;

            do
            {
                // setting the node size for each iteration
                node_Space_H = Math.Pow(10, -index);

                form_Two_Value = formula_Two(x_not, node_Space_H);
                form_Thr_Value = formula_Three(x_not, node_Space_H);
                form_Ten_Value = formula_Ten(x_not, node_Space_H);

                form_Two_error = function_Value - form_Two_Value;
                form_Thr_error = function_Value - form_Thr_Value;
                form_Ten_error = function_Value - form_Ten_Value;

                // computes the values and outputs to the console foreach lines
                Console.WriteLine("  10^-{0,-2}| | {1,16} | {2,16} | | {3, 16} | {4, 16} | | {5, 16} | {6, 16} ||"
                                  , index
                                  , String.Format("{0:N13}", form_Two_Value)
                                  , String.Format("{0:N13}", form_Two_error)
                                  , String.Format("{0:N13}", form_Thr_Value)

                                  , String.Format("{0:N13}", form_Thr_error)
                                  , String.Format("{0:N13}", form_Ten_Value)
                                  , String.Format("{0:N13}", form_Ten_error)
                                  );

                double previouse_Node = Math.Pow(10, -(index - 1) );
                double next_Node = Math.Pow(10, -(index + 1));


                // conditional statements foreach of the formulas
                if (index != 1 && ( Math.Abs(formula_Two(x_not, next_Node) - formula_Two(x_not, node_Space_H))) 
                                 >= Math.Abs((formula_Two(x_not, node_Space_H) - formula_Two(x_not, previouse_Node))) && !form_Two)
                {
                    form_Two = true;
                    form_Two_Optimal_H = index;
                }
                if (index != 1 && (Math.Abs(formula_Three(x_not, next_Node) - formula_Three(x_not, node_Space_H))) 
                                >= Math.Abs((formula_Three(x_not, node_Space_H) - formula_Three(x_not, previouse_Node))) && !form_Thr)
                {
                    form_Thr = true;
                    form_Thr_Optimal_H = index;
                }
                if (index != 1 && (Math.Abs(formula_Ten(x_not, next_Node) - formula_Ten(x_not, node_Space_H))) 
                                >= Math.Abs((formula_Ten(x_not, node_Space_H) - formula_Ten(x_not, previouse_Node))) && !form_Ten)
                {
                    form_Ten = true;
                    form_Ten_Optimal_H = index;
                }

                if (form_Two && form_Thr && form_Ten && continue_Iterating > 5)
                {
                    continue_Iterating = 2;
                }
                else if(continue_Iterating > 5)
                {
                    continue_Iterating = 10;
                }

                continue_Iterating--;

                index++;
            }
            while (continue_Iterating > 0);

            /// printing the last couple output strings
            Console.WriteLine("--------| |------------------|------------------| |------------------|------------------| |------------------|------------------|| ");
            Console.WriteLine();


            node_Space_H = Math.Pow(10, -form_Two_Optimal_H);
            Console.WriteLine("Optimal step size for each method : formula (2) : 10^-{0} at f'(x0) = {2}", form_Two_Optimal_H, x_not, String.Format("{0:N13}", formula_Two(x_not, node_Space_H)));
            node_Space_H = Math.Pow(10, -form_Thr_Optimal_H);
            Console.WriteLine("                                    formula (3) : 10^-{0} at f'(x0) = {2}", form_Thr_Optimal_H, x_not, String.Format("{0:N13}", formula_Three(x_not, node_Space_H)));
            node_Space_H = Math.Pow(10, -form_Ten_Optimal_H);
            Console.WriteLine("                                    formula (10): 10^-{0} at f'(x0) = {2}", form_Ten_Optimal_H, x_not, String.Format("{0:N13}", formula_Ten(x_not, node_Space_H)));
        }

        static double formula_Two(double x_input, double node_Space_H)
        {
            return ( function(x_input + node_Space_H) 
                   - function(x_input)) 
                   / node_Space_H;
        }

        static double formula_Three(double x_input, double node_Space_H)
        {
            return ( function(x_input + node_Space_H) 
                   - function(x_input - node_Space_H)) 
                   / (2 * node_Space_H);
        }

        static double formula_Ten(double x_input, double node_Space_H)
        {
            return ( (-1) * function(x_input + 2 * node_Space_H) 
                      + 8 * function(x_input + node_Space_H) 
                      - 8 * function(x_input - node_Space_H) 
                      +     function(x_input - 2 * node_Space_H)) 
                      / (12 * node_Space_H);
        }
    }
}

// output of console 
//--------| |-------------------------------------| |-------------------------------------| |-------------------------------------||
//  step  | | Approximation by |    Error using   | | Approximation by |    Error using   | | Approximation by |   Error using    ||
//  size  | |    formula (2)   |    formula (2)   | |    formula (3)   |    formula (3)   | |   formula (10)   |   formula (10)   ||
//--------| |------------------|------------------| |------------------|------------------| |------------------|------------------||
//  10^-1 | |  1.4102689808905 | -6.6709756208746 | | -4.7231852939287 | -0.5375213460554 | | -5.5680910850784 |  0.3073844450943 ||
//  10^-2 | | -4.5414390213222 | -0.7192676186619 | | -5.2566545045505 | -0.0040521354337 | | -5.2607664030114 |  0.0000597630273 ||
//  10^-3 | | -5.1890378788961 | -0.0716687610880 | | -5.2606662672138 | -0.0000403727703 | | -5.2607066459940 |  0.0000000060099 ||
//  10^-4 | | -5.2535432905498 | -0.0071633494343 | | -5.2607062362703 | -0.0000004037139 | | -5.2607066399839 | -0.0000000000002 ||
//  10^-5 | | -5.2599903412887 | -0.0007162986955 | | -5.2607066359567 | -0.0000000040275 | | -5.2607066399960 |  0.0000000000119 ||
//  10^-6 | | -5.2606350106066 | -0.0000716293776 | | -5.2607066400867 |  0.0000000001026 | | -5.2607066402070 |  0.0000000002228 ||
//  10^-7 | | -5.2606994760396 | -0.0000071639446 | | -5.2607066403088 |  0.0000000003246 | | -5.2607066401237 |  0.0000000001396 ||
//  10^-8 | | -5.2607059153331 | -0.0000007246510 | | -5.2607066369781 | -0.0000000030061 | | -5.2607066416040 |  0.0000000016199 ||
//  10^-9 | | -5.2607066480803 |  0.0000000080962 | | -5.2607067591026 |  0.0000001191185 | | -5.2607068238656 |  0.0000001838815 ||
//  10^-10| | -5.2607052047904 | -0.0000014351938 | | -5.2607052047904 | -0.0000014351938 | | -5.2607048347160 | -0.0000018052681 ||
//--------| |------------------|------------------| |------------------|------------------| |------------------|------------------||
//
//Optimal step size for each method : formula (2) : 10^-9 at f'(x0) = -5.2607066480803
//                                    formula (3) : 10^-7 at f'(x0) = -5.2607066403088
//                                    formula (10): 10^-5 at f'(x0) = -5.2607066399960
