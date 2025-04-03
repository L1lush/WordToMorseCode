using System;
using System.Collections.Generic;
using System.Threading;

namespace WordToMorse
{
	class MorseCodeConverter
	{
		static void Main()
		{
			Dictionary<char, string> morseCodeDict = new Dictionary<char, string>() // create dictionary  
		{
			{'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."}, {'F', "..-."},
			{'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"}, {'K', "-.-"}, {'L', ".-.."},
			{'M', "--"}, {'N', "-."}, {'O', "---"}, {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."},
			{'S', "..."}, {'T', "-"}, {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"},
			{'Y', "-.--"}, {'Z', "--.."},
			{'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"}, {'4', "....-"},
			{'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."}, {'9', "----."}
		};

			Console.Write("Enter your phrase ");
			string input = Console.ReadLine().ToUpper();

			string morseCode = ConvertToMorseCode(input, morseCodeDict);
			Console.WriteLine($"Morse Code: {morseCode}");

			PlayMorseCode(morseCode);
		}

		static string ConvertToMorseCode(string input, Dictionary<char, string> morseCodeDict) // convert word to morse code
		{
			string morseCode = "";
			int i = 0;

			while (i < input.Length)
			{
				char c = input[i];
				if (morseCodeDict.ContainsKey(c))
				{
					morseCode += morseCodeDict[c] + " ";
				}
				else if (c == ' ')
				{
					morseCode += "/ ";
				}
				i++;
			}

			return morseCode.Trim();
		}

		static void PlayMorseCode(string morseCode)
		{
			foreach (char symbol in morseCode)
			{
				if (symbol == '.')
				{
					// Short beep for dot
					Console.Beep(1000, 200);
					Thread.Sleep(200);
				}
				else if (symbol == '-')
				{
					// Long beep for dash
					Console.Beep(1000, 600);
					Thread.Sleep(200);
				}
				else if (symbol == ' ')
				{
					// Pause between characters
					Thread.Sleep(200);
				}
				else if (symbol == '/')
				{
					// Pause between words
					Thread.Sleep(1000);
				}
			}
		}
	}
}