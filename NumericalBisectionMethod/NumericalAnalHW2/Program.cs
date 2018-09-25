using System;
using System.Linq;

namespace NumericalAnalHW2
{
    class Program
    {
        static double lastXValue = 0;

        static void Main()
        {
            double xNotValue  = 1;
            double newXNot    = 0;
            int    index      = 0;
            bool   returnValue = false;

            do
            {

                newXNot = IterateFunc(xNotValue);
                CheckDecimals(index, newXNot);
                xNotValue = newXNot;


                index++;

            } while (!returnValue);
        }

        private static double IterateFunc(double inputValue)
        {
            double outPutValue = 0;

            outPutValue = inputValue - ((Function(inputValue)) / (Derivative(inputValue)));

            return outPutValue;
        }

        private static double Function(double input)
        {
            double outPutValue = Math.Sin(input) + (Math.Pow(input, 2) * Math.Cos(input)) - Math.Pow(input, 2) - input;

            return outPutValue;
        }

        private static double Derivative(double input)
        {
            double outPutValue = Math.Cos(input) + (2 * (input) * Math.Cos(input)) - Math.Pow(input, 2) * Math.Sin(input) - 2 * input - 1;

            return outPutValue;
        }

        private static bool CheckDecimals(int index, double xInputValue)
        {
            bool returnValue = false;
            int iterationCounter = 0;

            if (index < 1)
                lastXValue = xInputValue;
            else
            {
                char[] prevXValue = lastXValue.ToString().Take(7).ToArray();
                char[] nextXValue = xInputValue.ToString().Take(7).ToArray();

                for (int i = 0; i < 7; i++)
                {
                    if(prevXValue[i] == nextXValue[i])
                    {
                        if (iterationCounter == 6)
                        {
                            returnValue = true;
                        }
                        else
                            iterationCounter++;
                    }
                    else
                    {
                        lastXValue = xInputValue;
                        goto numbers_didnt_match;
                    }
                }
            }

            numbers_didnt_match:

            return returnValue;
        }
    }
}
