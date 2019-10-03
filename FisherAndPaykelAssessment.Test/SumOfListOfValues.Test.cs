using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FisherAndPaykelAssessment.Test
{
	public class SumOfListOfValues
	{

		public static IEnumerable<object[]> SumOfListOfValuesTestData => new[]
		{
			new object[]
			{
				new List<long>{-15,100,333,-99,19,22,0}, 0 ,true},
				new object[] { new List<long>{-11,22,33}, 12, false },
				new object[] { new List<long>{1001,23},7, false },
			};


		[Theory]
		[MemberData(nameof(SumOfListOfValuesTestData))]
		public void Test_SumOfListOfValues_New_Value_Totals(List<long> listOfDigits, int expected, bool allowNegatives)
		{

			var result = new List<long>();
			var errors = new List<string>();

			for (int i = 0; i < listOfDigits.ToList().Count(); i++)
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

			var sumOfNewValues = result.Sum();

			Assert.True(sumOfNewValues == expected);
		}
	}
}