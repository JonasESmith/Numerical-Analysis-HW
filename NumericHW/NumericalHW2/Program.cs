///<summary>
/// Programmer : Jonas Smith
/// Purpose    : Use newtons method to find root for given function f(x)
/// </summary>
using System;
using System.Linq;

namespace NumericalAnalHW2
{
  class Program
  {
    /// This value needs to be global as it is passed around a lot for the entire applicaiton
    static decimal lastXValue = 0;

    static void Main()
    {
      /// Init values used in bellow methods that don't need to be global to the class
      decimal xNotValue    = 1;
      decimal newXNot     = 0;
      int     index       = 0;
      bool    returnValue = false;
      
      /// Print's headers for the application telling who the programmer is and purpose
      PrintHeader();

      /// While(!false) continue to iterate through, only true when the last 5 decimals of the next_X_Value match
      do
      {
        /// Get new X_n value from calling IteracteFunc which uses Newtons root method
        newXNot     = IterateFunc(xNotValue);

        /// Checks the last five decimals of a number to make sure they are matching
        returnValue = CheckDecimals(index, newXNot);

        /// prints current X_n-1 and X_n I print it here instead of storing the value 
        ///   just cus
        PrintData(index, newXNot);

        // Swap values for the next iteration.
        lastXValue  = newXNot;
        xNotValue   = newXNot;

        /// increment index for data printing and other function needs
        index++;

      } while (!returnValue);

      Console.ReadLine();
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
        char[] prevXValue = lastXValue.ToString().Take(8).ToArray();
        char[] nextXValue = xInputValue.ToString().Take(8).ToArray();

        for (int i = 0; i < 8; i++)
        {
          if (prevXValue[i] == nextXValue[i])
          {
            if (iterationCounter == 7)
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
        Console.WriteLine("{0,-3} X_Value     : {1}", ++index + ".", 1.0000000);
        Console.WriteLine("    f(x) Output : {0}", xValue);
        Console.WriteLine();
      }

      else
      {
        Console.WriteLine("{0,-3} X_Value     : {1}", ++index + ".", lastXValue);
        Console.WriteLine("    f(x) Output : {0}", xValue);
        Console.WriteLine();
      }
    }
  }
}
