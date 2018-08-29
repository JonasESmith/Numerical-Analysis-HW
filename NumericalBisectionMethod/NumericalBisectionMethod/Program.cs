
using System;
/// <summary>
///     Programmer : Jonas Smith
///     Date start : 8/29/18
///     Purpose    : Create program that uses bisectin method to find zero between points
/// </summary>
namespace NumericalBisectionMethod
{
  class Program
  {
    static double str_X = 0.5;
    static double end_X = 4.5;

    static double iterations = 15; 
    
    // Initial function f(x) = (x-2)^2 - ln(x) = 0; 

    static void Main(string[] args)
    {
      double pointOne = 0;

      for(int index = 0; index < iterations; index++)
      {
        pointOne = (str_X + end_X) / 2;
        if(function(pointOne) > function(str_X))
        {

        }
        else
        {
          end_X = pointOne;
        }
        // if (pointOne is negative then we need to take numbers to the right or left)
      }
    }

    static double function(double xValue)
    {
      double yValue = Math.Pow((xValue - 2), 2) - Math.Log(xValue);

      return yValue;
    }
  }
}
