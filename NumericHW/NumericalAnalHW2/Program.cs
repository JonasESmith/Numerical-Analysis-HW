using System;
using System.Linq;

namespace NumericalAnalHW2
{
  class Program
  {
    static decimal lastXValue = 0;

    static void Main()
    {
      decimal xNotValue = 1;
      decimal newXNot = 0;
      int index = 0;
      bool returnValue = false;

      PrintHeader();

      do
      {

        newXNot = IterateFunc(xNotValue);
        CheckDecimals(index, newXNot);
        PrintData(index, newXNot);
        lastXValue = newXNot;
        xNotValue = newXNot;


        index++;

      } while (!returnValue);
    }

    private static decimal IterateFunc(decimal inputValue)
    {
      decimal outPutValue = 0;

      outPutValue = inputValue - ((Function(inputValue)) / (Derivative(inputValue)));

      return outPutValue;
    }

    private static decimal Function(decimal input)
    {
      double doubleInput = Convert.ToDouble(input);

      decimal outPutValue = Convert.ToDecimal(Math.Sin(doubleInput) + 
                                             (Math.Pow(doubleInput, 2) * 
                                             Math.Cos(doubleInput)) - 
                                             Math.Pow(doubleInput, 2) - 
                                             doubleInput);

      return outPutValue;
    }

    private static decimal Derivative(decimal input)
    {
      double doubleInput = Convert.ToDouble(input);

      decimal outPutValue = Convert.ToDecimal(Math.Cos(doubleInput) + 
                                              (2 * (doubleInput) * Math.Cos(doubleInput)) - 
                                              Math.Pow(doubleInput, 2) * 
                                              Math.Sin(doubleInput) - 
                                              2 * doubleInput - 1);

      return outPutValue;
    }

    private static bool CheckDecimals(int index, decimal xInputValue)
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
          if (prevXValue[i] == nextXValue[i])
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
            //lastXValue = xInputValue;
            goto numbers_didnt_match;
          }
        }
      }

      numbers_didnt_match:

      return returnValue;
    }

    private static void PrintHeader()
    {
      Console.WriteLine("Programmer : Jonas Smith");
      Console.WriteLine("Purpose    : Numerical HW2");
    }

    private static void PrintData(int index, decimal xValue)
    {
      if(index < 1)
      {
        Console.WriteLine("{0,-3} (input)  : {1}", ++index + ".", 1.0000000);
        Console.WriteLine("    f(output) : {0}", xValue);
        Console.WriteLine();
      }

      else
      {
        Console.WriteLine("{0,-3} f(input)  : {1}",++index + ".", lastXValue);
        Console.WriteLine("    f(output) : {0}", xValue);
        Console.WriteLine();
      }
    }
  }
}
