using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalHW4
{
    class NumericalHw4
    {

        // Init pointsList for use in the different approximations. These are the points given from the HW.
        public static List<Point> points_List = new List<Point>()
        {   // new Point( xVal, yVal),
            new Point( 0   , 2      ),
            new Point( 1   , 5.4375 ),
            new Point( 2.5 , 7.3516 ),
            new Point( 3   , 7.5625 ),
            new Point( 4.5 , 8.4453 ),
            new Point( 5   , 9.1875 ),
            new Point( 6   , 12     )  };

        static void Main()
        {
            // Takes passed x_value and approximates the value of the Lagrange interpolating polynomial
            LagrangePolynomial(2.75);

            NewtonPolynomial(points_List.Count, 2.75);
            Console.ReadLine();
        }


        static double LagrangePolynomial(double x_Value)
        {
            int Degree = points_List.Count;

            double approximate = 0.0;
            double value = 1.0;

            for(int i = 0; i < Degree; i++)
            {
                value = 1.0;

                for (int j = 0; j < Degree; j++)
                {
                    if(i != j)
                        value *= (x_Value - points_List[j].X) / (points_List[i].X - points_List[j].X);
                }
                value *= points_List[i].Y;

                approximate += value;
            }

            Console.WriteLine("{0,3} = {1}", x_Value, approximate);
            return approximate;
        }

        // recursive method to find Newton polynomial
        static double NewtonPolynomial(int index, double xValue)
        {
            double value = 0;
            double multipliedValue;

            if(index != 0)
            {
                multipliedValue = 1.0;
                for (int i = index; i > 0; i++)
                {
                    multipliedValue *= (xValue - points_List[i].X);
                }
                value += points_List[index].Y * multipliedValue;

            }
            else if(index == 0)
            {
                value += points_List[index].Y;
            }

            return value;
        }
    }
}
