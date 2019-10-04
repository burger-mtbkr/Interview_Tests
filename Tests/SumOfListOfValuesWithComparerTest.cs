using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FisherAndPaykelAssessment.Test
{
	public class SumOfListOfValuesWithComparerTest
	{

		/// <summary>
		/// Unit test which will sum the digits of each value in the input list and add that value to a new list then order it from smallest to largest.
		/// The test will add up the new values and test again the total sum of the new values.
		/// create a new value and return the list of new values ordered from lowest to highest.
		/// </summary>
		/// <param name = "listOfDigits" ></ param >
		/// < param name= "expected" ></ param >
		/// < param name= "allowNegatives" ></ param >
		[Theory]
		[InlineData("103 123 4444 99 2000", "2000 103 123 4444 99")]
		[InlineData("2000 10003 1234000 44444444 9999 11 11 22 123", "11 11 2000 10003 22 123 1234000 44444444 9999")]
		public void SumOfListOfValuesWithComparer_Test(string strng, string expected)
		{
			// get list of ints from input string
			var result = strng.Split(' ').OrderBy(s => s, new WeightedDigitComparer());
			
			var final = string.Join(" ", result);
			Assert.Equal(final, expected);
		}


		/// <summary>
		/// WeightedDigitComparer  will provide a way to customize the sort order of a collection 
		/// since we need to compare strings for weights that are the same and weight numbers that are not.
		/// </summary>
		public class WeightedDigitComparer : IComparer<string>
		{
			// still have bugs = crash with names
			// make it readable
			// follows known pattern
			public int Compare(string x, string y)
			{

				var xWeight = x.Select(s => int.Parse(s.ToString())).ToArray();

				var yWeight = y.Select(s => int.Parse(s.ToString())).ToArray();
			
				// xSum = digit weigth of X
				var xsum = xWeight.Sum();

				// ySum = digit weight of yes
				var ysum = yWeight.Sum();

				// when equal weghting then compare then as strings
				if (xsum == ysum)
				{					
					return string.Compare(x.ToString(), y.ToString());
				}
				else
				{
					// else by number
					return xsum - ysum;
				}
			}
		}

	}
}