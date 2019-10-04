using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FisherAndPaykelAssessment.Test
{
	public class NonRepeatingCharTest
	{
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
		[InlineData("STreSS", "T")]
		[InlineData("STreSS", "t")]
		[InlineData("1233", "1")]
		[InlineData(" o an@#o$%$*(gkb&*%", "a")]
		[InlineData("123abc456def", "1")]
		[InlineData("Loan@#$%$LL*(gkb&*%", "o")]
		[InlineData("extensibility", "x")]
		[InlineData("_&)(&KJ75468600", "_")]
		[InlineData("", "")]
		[InlineData(" ", " ")]
		[InlineData(null, "")]
		[InlineData("stress", "t")]
		public void FirstNonRepeatingChar_Dictionary_Test(string str, string expected)
		{
			var charDictionary = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);		

			if (!string.IsNullOrEmpty(str))
			{
				int temp = 0;
				foreach (char c in str.ToCharArray())
				{

					var cString = c.ToString();

					if (charDictionary.ContainsKey(cString))
					{
						temp = charDictionary[cString];
						charDictionary[cString] = temp + 1;
						continue;
					}
					charDictionary.Add(cString, 1);
				}
			}

			var firstcharchar = string.Empty;
			if (charDictionary.Values.Contains(1))
			{
				firstcharchar = charDictionary.First(x => x.Value == 1).Key;
			}

			Console.WriteLine(firstcharchar);

			Assert.True(firstcharchar == expected);
		}
	}
}
