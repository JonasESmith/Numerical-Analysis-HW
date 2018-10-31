using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalHW4
{
    class NumericalHw4
    {

        // Init pointsList for use in the different approximations. These are the points given in the HW.
        public static List<Point> points_List = new List<Point>()
        {
            new Point( 0.0, -6.00000 ),
            new Point( 0.1, -5.89483 ),
            new Point( 0.3, -5.65014 ),
            new Point( 0.6, -5.17788 ),
            new Point( 1.0, -4.28172 )
        };

        public static List<double> aValues = new List<double>();

        static void Main()
        {
            // Takes passed x_value and approximates the value of the Lagrange interpolating polynomial
            // These two functions bellow actually approximate the functions for the lagrange and newton method.
            LagrangePolynomial(1.0);
            NewtonPolynomial(points_List.Count, 1.0, 0);


            FindCoefficiants();
            Console.WriteLine("P{0}(X) = {1}", points_List.Count - 1, LagrangePolynomialString(""));
            Console.WriteLine("P{0}(X) = {1}", points_List.Count - 1, NewtonPolynomialString(points_List.Count, 1.0, ""));

            Console.ReadLine();
        }

        static string LagrangePolynomialString(string x_Value)
        {
            int Degree = points_List.Count;

            double denominator = 1.0;
            string approximate = "";
            string value = "";

            for (int i = 0; i < Degree; i++)
            {
                value = String.Format("[ {0} (", points_List[i].Y); 

                denominator = 1.0;
                for (int j = 0; j < Degree; j++)
                {
                    string newValue = String.Format("({0} - {1})", "X", points_List[j].X);
                    if (i != j)
                    {
                        value += newValue;
                        denominator *= (points_List[i].X - points_List[j].X);
                    }
                }
                value += ") / " + denominator.ToString() + " ]";

                if (i < Degree - 1)
                    value += " + ";
                approximate += value;
            }

            return approximate;
        }

        // recursive method to find Newton polynomial
        static string NewtonPolynomialString(int index, double xValue, string passedValue)
        {
            // This finds the coefficients for newtons polynomial method
            FindCoefficiants();

            string value = passedValue;
            string multipliedValue = "";
            string buffer = " + ";

            if (index > 0)
            {
                if (index == 1)
                    multipliedValue = "";
                else
                    multipliedValue = buffer;
                for (int i = index - 1; i > 0; i--)
                {
                    string newValue = String.Format("({0} - {1})", "X", points_List[i - 1].X);
                    multipliedValue += (newValue);
                }

                value += NewtonPolynomialString(index - 1, xValue, value) + (multipliedValue + aValues[index - 1]);
            }

            return value;
        }

        static double LagrangePolynomial(double x_Value)
        {
            int Degree = points_List.Count;

            double approximate = 0.0;
            double value = 1.0;

            for (int i = 0; i < Degree; i++)
            {
                value = 1.0;

                for (int j = 0; j < Degree; j++)
                {
                    if (i != j)
                        value *= (x_Value - points_List[j].X) / (points_List[i].X - points_List[j].X);
                }
                value *= points_List[i].Y;

                approximate += value;
            }

            return approximate;
        }

        // recursive method to find Newton polynomial
        static double NewtonPolynomial(int index, double xValue, double passedValue)
        {
            // This finds the coefficients for newtons polynomial method
            FindCoefficiants();

            double value = passedValue;
            double multipliedValue;

            if (index > 0)
            {
                multipliedValue = 1.0;
                for (int i = index - 1; i > 0; i--)
                {
                    multipliedValue *= (xValue - points_List[i - 1].X);
                }
                value += NewtonPolynomial(index - 1, xValue, value) + aValues[index - 1] * multipliedValue;
            }

            return value;
        }

        // Finds the coefficients used for the newtonian method. 
        static void FindCoefficiants()
        {
            aValues.Clear();

            int count = 1;
            double[,] table = new double[points_List.Count, points_List.Count];

            aValues.Add(points_List[0].Y);
            for (int i = 0; i < points_List.Count; i++)
            {
                table[0, i] = points_List[i].Y;
            }

            for (int i = 1; i < points_List.Count; i++)
            {
                for (int j = count; j < points_List.Count; j++)
                {
                    table[i, j] = (table[i - 1, j] - table[i - 1, j - 1]) / (points_List[j].X - points_List[j - count].X);

                    if (j == count)
                    {
                        aValues.Add(table[i, j]);
                    }
                }

                count++;
            }
        }
    }
}



/// Console Outputs
/// Newtonian Method
/// P4(X) = -6 + (X - 0)1.0517 
///            + (X - 0.1)(X - 0)0.572499999999983 
///            + (X - 0.3)(X - 0.1)(X - 0)0.215000000000042 
///            + (X - 0.6)(X - 0.3)(X - 0.1)(X - 0)0.0630158730158207
///            
/// Lagrange Method
/// P4(X) = [ -6 ((X - 0.1)(X - 0.3)(X - 0.6)(X - 1)) / 0.018 ] 
///            + [ -5.89483 ((X - 0)(X - 0.3)(X - 0.6)(X - 1)) / -0.009 ] 
///            + [ -5.65014 ((X - 0)(X - 0.1)(X - 0.6)(X - 1)) / 0.0126 ] 
///            + [ -5.17788 ((X - 0)(X - 0.1)(X - 0.3)(X - 1)) / -0.036 ] 
///            + [ -4.28172 ((X - 0)(X - 0.1)(X - 0.3)(X - 0.6)) / 0.252 ]