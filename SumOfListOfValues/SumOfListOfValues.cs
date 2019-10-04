using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FisherAndPaykelAssessment
{
	/// <summary>
	/// See this for sum of digits
	/// https://stackoverflow.com/questions/478968/sum-of-digits-in-c-sharp
	/// </summary>
	public class SumOfListOfValues
	{
		/// <summary>
		/// Given a list of values, sum the digits of each value to create a new value and return the list of new values ordered from lowest to highest.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{

			var list = new List<long>
			{
				-15,
				100,
				333,
				-99,
				19,
				22,
				0
			};

			var result = CalculateSumOfListOfValues(list, true);
			foreach (var item in result.numbers)
			{
				Console.WriteLine($"{item}");
			}

			foreach (var err in result.errors)
			{
				Console.WriteLine(err);
			}
		}

		/// <summary>
		/// Calculate Sum Of List Of Values
		/// Allow provision for how we want to treat negative numbers
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="I"></typeparam>
		/// <param name="listOfDigits"></param>
		/// <returns></returns>
		public static (List<long>numbers,List<string> errors) CalculateSumOfListOfValues(List<long> listOfDigits, bool allowNegatives = false)
		{
			var result = new List<long>();
			var errors = new List<string>();

			if(listOfDigits?.Any() == false)
			{
				errors.Add("There are no digits to use for the calculation.");
			}

			for (int i = 0; i < listOfDigits?.Count(); i++)
			{
				var someInt = listOfDigits[i];

				// make sure its a valid int
				if (Int64.TryParse(someInt.ToString(), out long n))
				{
					if (!allowNegatives)
					{
						// if we dont want to allow negatives then get the Absolte value for n
						n = Math.Abs(n);
					}
					long sum = 0;
					while (n != 0)
					{
						sum += n % 10;

						// set n to 
						n = n / 10;
					}
					result.Add(sum);
				}
				else
				{
					errors.Add($"{someInt} is not a valid long");
				}
			}			
			
			// sort from smallest to largest
			result.Sort();

			return (result, errors);
		}
	}
}
