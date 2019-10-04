using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Fibonacci
{
	class Fibonacci
	{
		static void Main(string[] args)
		{
			// not one
			//GetFibonacciForNumber(44);
			GetFibonacciForNumber(34);
			//	GetFibonacciForNumber(5);
		}

		/// <summary>
		/// Using a FOR Loop
		/// </summary>
		/// <param name="fibonacciNumber"></param>
		private static void GetFibonacciForNumber(int fibonacciNumber)
		{

			var fibonacciFound = false;
			var fibonacciSequenceList = new List<int>();

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
					if(c>fibonacciNumber)
					{
						fibonacciSequenceList = new List<int>();					
					}
					else if(c == fibonacciNumber)
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

			if(fibonacciFound && fibonacciSequenceList.Any())
			{

				var fibonacciSequencString = string.Join(" ",fibonacciSequenceList);

				Console.WriteLine($"Fibonacci sequence for {fibonacciNumber} is:");
				Console.WriteLine(fibonacciSequencString);
			}
			else
			{
				Console.WriteLine($"Unable to determine the fibonacci for {fibonacciNumber}");
			}		
		}
	}
}
