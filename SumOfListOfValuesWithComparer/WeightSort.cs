using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfListOfValuesWithComparer
{
	class WeightSort
	{
		static void Main(string[] args)
		{

			var final = OrderWeight("2000 10003 1234000 44444444 9999 11 11 22 123");
			Console.WriteLine(final);
		}

		public static string OrderWeight(string strng)
		{
			// get list of ints from input string
			var result = strng.Split(' ').OrderBy(s => s, new WeightedDigitComparer());

			var final = string.Join(" ", result);

			return final;	
		}

		/// <summary>
		/// WeightedDigitComparer  will provide a way to customize the sort order of a collection 
		/// since we need to compare strings for weights that are the same and weight numbers that are not.
		/// </summary>
		public class WeightedDigitComparer : IComparer<string>
		{
			public int Compare(string a, string b)
			{
				//var xWeight = a.Select(s => int.Parse(s.ToString())).ToArray();				
				// Select ontly the numrics fromt he string and disregard the alpha segments
				var xWeight = a.Select(s =>
				{
					int value;
					bool success = int.TryParse(s.ToString(), out value);
					return new { value, success };
				})
				.Where(pair => pair.success)
				.Select(pair => pair.value).ToArray();

				//var yWeight = b.Select(s => int.Parse(s.ToString())).ToArray();
				// Select ontly the numrics fromt he string and disregard the alpha segments			
				var yWeight = b.Select(s =>
				{
					int value;
					bool success = int.TryParse(s.ToString(), out value);
					return new { value, success };
				})
				.Where(pair => pair.success)
				.Select(pair => pair.value).ToArray();

				// xSum = digit weigth of X
				var xsum = xWeight.Sum();

				// ySum = digit weight of yes
				var ysum = yWeight.Sum();

				// when equal weghting then compare then as strings
				if (xsum == ysum)
				{
					return string.Compare(a.ToString(), b.ToString());
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
