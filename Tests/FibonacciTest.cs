using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace FisherAndPaykelAssessment.Test
{
	public class FibonacciTest
	{

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fibonacciNumber"></param>
		[Theory]
		//[InlineData(34, "0 1 1 2 3 5 8 13 21 34")]
		//[InlineData(13, "0 1 1 2 3 5 8 13")]
		//[InlineData(44, "")]
	//	[InlineData(-1, "")]
		[InlineData(0, "0")]

		public void FibonacciSequenceForNumber_Test(int fibonacciNumber, string expected)
		{
			var fibonacciSequencString = string.Empty;
			var fibonacciFound = false;
			var fibonacciSequenceList = new List<int>();


			if (fibonacciNumber > 0)
			{
				int a = 0;
				int b = 1;
				int c = 0;

				//Console.Write($"{a} {b}");
				fibonacciSequenceList.Add(a);
				fibonacciSequenceList.Add(b);

				for (int i = 2; i <= fibonacciNumber; i++)
				{
					c = a + b;

					if (c >= fibonacciNumber)
					{
						if (c > fibonacciNumber)
						{
							fibonacciSequenceList = new List<int>();
						}
						else if (c == fibonacciNumber)
						{
							//Console.Write($" {c} ");		
							fibonacciFound = true;
							fibonacciSequenceList.Add(c);
						}
						break;
					}

					fibonacciSequenceList.Add(c);

					a = b;
					b = c;
				}
			}
			else if(fibonacciNumber == 0)
			{
				fibonacciFound = true;
				fibonacciSequenceList.Add(fibonacciNumber);
			}

			if (fibonacciFound && fibonacciSequenceList.Any())
			{

				fibonacciSequencString = string.Join(" ", fibonacciSequenceList);

				Console.WriteLine($"Fibonacci sequence for {fibonacciNumber} is:");
				Console.WriteLine(fibonacciSequencString);
			}
			else
			{
				Console.WriteLine($"Your input number {fibonacciNumber} is not a fibonacci number");
			}

			Assert.Equal(expected, fibonacciSequencString);
		}
	}
}
