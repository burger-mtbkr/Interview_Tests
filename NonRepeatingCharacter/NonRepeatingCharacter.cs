using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FisherAndPaykelAssessment
{
	class NonRepeatingCharacter
	{
		static void Main(string[] args)
		{
			var linqOption = FirstNonRepeatedCharInStringLinq("Loan@#$%$LL*(gkb&*%");
			var linqResult = linqOption.ToString();

			var dictionaryOption = FirstNonRepeatedCharInStringDictionary("Loan@#$%$LL*(gkb&*%");
			var dictionaryResult = linqOption.ToString();


			Console.WriteLine(linqResult);
			Console.WriteLine(dictionaryResult);
		}

		/// <summary>
		/// In this example we will use LINQ to group the characters in the string.
		/// If there are any then we select the group where the count is 1
		/// If there are any of those - we return the fist one whcih will be our non repeating char
		/// </summary>
		/// <param name="str"></param>
		public static string FirstNonRepeatedCharInStringLinq(string str)
		{
			var firstcharchar = ' ';

			if (!string.IsNullOrEmpty(str))
			{
				var group = str.GroupBy(c => c).ToList();
				if (group?.Any() == true)
				{
					var singles = group.Where(g => g.Count() == 1);
					if (singles?.Any() == true)
					{
						firstcharchar = singles.First().Key;
					}
				}
			}

			return firstcharchar.ToString();
		}

		/// <summary>
		/// This method will use a dictionary to store the character and counts as the key values
		/// We will itterate through the characters by creating a Character Array from the string
		/// then see if the dictionary contains the character -
		/// if it does then we get that value and increment it by 1 and set that as the new value for the char key in the dictionary.
		/// If it does not contain it then we add the char as key to the dictionary and set the value to 1		/// 
		/// </summary>
		/// <param name="str"></param>
		public static char FirstNonRepeatedCharInStringDictionary(string str)
		{
			var charDictionary = new Dictionary<char, int>();

			if (!string.IsNullOrEmpty(str))
			{
				int temp = 0;
				foreach (char c in str.ToCharArray())
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

			return firstcharchar;
		}
	}
}
