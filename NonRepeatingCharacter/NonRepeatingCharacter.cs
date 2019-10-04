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
			var dictionaryResult = FirstNonRepeatedCharInStringDictionary("Loan@#$%$LL*(gkb&*%");		
	
			Console.WriteLine(dictionaryResult);
		}

		/// <summary>
		/// This method will use a dictionary to store the character and counts as the key values
		/// We will itterate through the characters by creating a Character Array from the string
		/// then see if the dictionary contains the character -
		/// if it does then we get that value and increment it by 1 and set that as the new value for the char key in the dictionary.
		/// If it does not contain it then we add the char as key to the dictionary and set the value to 1		/// 
		/// </summary>
		/// <param name="str"></param>
		public static string FirstNonRepeatedCharInStringDictionary(string str)
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

			return firstcharchar;
		}
	}
}
