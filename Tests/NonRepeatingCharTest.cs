using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FisherAndPaykelAssessment.Test
{
	public class NonRepeatingCharTest
	{
		/// <summary>
		/// In this example we will use LINQ to group the characters in the string.
		/// If there are any then we select the group where the count is 1
		/// If there are any of those - we return the fist one whcih will be our non repeating char
		/// </summary>
		/// <param name="stringInput"></param>
		/// <param name="expected"></param>
		[Theory]
		[InlineData(" o an@#o$%$*(gkb&*%", 'a')]
		[InlineData("123abc456def", '1')]
		[InlineData("aaaaaaaaaaaaa", ' ')]
		[InlineData("Loan@#$%$LL*(gkb&*%", 'o')]
		[InlineData("extensibility", 'x')]
		[InlineData("_'&)(&KJ75468600", '_')]
		[InlineData("", ' ')]
		[InlineData(" ", ' ')]
		[InlineData(null, ' ')]
		public void FirstNonRepeatingChar_Linq_Test(string stringInput, char expected)
		{
			var firstcharchar = ' ';

			if (!string.IsNullOrEmpty(stringInput))
			{
				var group = stringInput.GroupBy(c => c).ToList();
				if (group?.Any() == true)
				{
					var singles = group.Where(g => g.Count() == 1);
					if (singles?.Any() == true)
					{
						firstcharchar = singles.First().Key;
					}
				}
			}

			Console.WriteLine(firstcharchar);

			Assert.True(firstcharchar == expected);
		}

		///// <summary>
		///// Test will use a dictionary to store the character and counts as the key values
		///// We will itterate through the characters by creating a Character Array from the string
		///// then see if the dictionary contains the character -
		///// if it does then we get that value and increment it by 1 and set that as the new value for the char key in the dictionary.
		///// If it does not contain it then we add the char as key to the dictionary and set the value to 1		/// 
		///// </summary>
		///// <param name="stringInput"></param>
		///// <param name="expected"></param>
		[Theory]
		[InlineData(" o an@#o$%$*(gkb&*%", 'a')]
		[InlineData("123abc456def", '1')]
		[InlineData("Loan@#$%$LL*(gkb&*%", 'o')]
		[InlineData("extensibility", 'x')]
		[InlineData("_'&)(&KJ75468600", '_')]
		[InlineData("", ' ')]
		[InlineData(" ", ' ')]
		[InlineData(null, ' ')]
		[InlineData("stress", 'T')]
		public void FirstNonRepeatingChar_Dictionary_Test(string stringInput, char expected)
		{
			var charDictionary = new Dictionary<char, int>();

			//if (!string.IsNullOrEmpty(stringInput))
			{
				int temp = 0;
				foreach (char c in stringInput.ToCharArray())
				{
					if (charDictionary.ContainsKey(c))
					{
						temp = charDictionary[c];
						charDictionary[c] = temp + 1;
						continue;
					}
					charDictionary.Add(c, 1);
				}
			}

			var firstcharchar = ' ';
			if (charDictionary.Values.Contains(1))
			{
				firstcharchar = charDictionary.First(x => x.Value == 1).Key;
			}

			Console.WriteLine(firstcharchar);
			Assert.True(firstcharchar == expected);
		}
	}
}
