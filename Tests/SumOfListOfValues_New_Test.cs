using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FisherAndPaykelAssessment.Test
{
	public class SumOfListOfValues_New_Test
	{
			   		 	

		/// <summary>
		/// Unit test which will sum the digits of each value in the input list and add that value to a new list then order it from smallest to largest.
		/// The test will add up the new values and test again the total sum of the new values.
		/// create a new value and return the list of new values ordered from lowest to highest.
		/// </summary>
		/// <param name="listOfDigits"></param>
		/// <param name="expected"></param>
		/// <param name="allowNegatives"></param>
		[Theory]
		[InlineData("103 123 4444 99 2000", "2000 103 123 4444 99")]
		[InlineData("2000 10003 1234000 44444444 9999 11 11 22 123", "11 11 2000 10003 22 123 1234000 44444444 9999")]
		public void SumOfListOfValues_New_Value_Totals_Test(string inputString, string expected)
		{


			var listOfDigits = inputString.Split(" ");

			var result = new List<long>();
			var errors = new List<string>();

			for (int i = 0; i < listOfDigits?.ToList().Count(); i++)
			{
				var someInt = listOfDigits[i];

				// make sure its a valid int
				if (Int64.TryParse(someInt.ToString(), out long n))
				{
					
					// if we dont want to allow negatives then get the Absolte value for n
					n = Math.Abs(n);
				
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

			var sumOfNewValues = result.Sum();

		//	var final = string.Join(" ", fibonacciSequenceList);

		//	Assert.True(sumOfNewValues == expected);
		}
	}
}