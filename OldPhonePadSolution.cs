using System;
using System.Collections.Generic;

public class OldPhonePadSolution
{
    public static string OldPhonePad(string input)
    {
        // Keypad mapping
        var keypad = new Dictionary<char, string>
        {
            {'1', "&'("},
            {'2', "ABC"},
            {'3', "DEF"},
            {'4', "GHI"},
            {'5', "JKL"},
            {'6', "MNO"},
            {'7', "PQRS"},
            {'8', "TUV"},
            {'9', "WXYZ"},
            {'0', " "}
        };

        string output = "";
        char previousChar = '\0';
        int count = 0;

        foreach (char c in input)
        {
            if (c == '#') break;

            if (c == '*') // Backspace functionality
            {
                if (output.Length > 0)
                    output = output.Remove(output.Length - 1);
                continue;
            }

            if (c == previousChar) // Same key pressed again
            {
                count++;
            }
            else
            {
                if (previousChar != '\0' && keypad.ContainsKey(previousChar))
                {
                    var characters = keypad[previousChar];
                    output += characters[(count - 1) % characters.Length];
                }
                previousChar = c;
                count = 1;
            }
        }

        // Handle the last character sequence
        if (previousChar != '\0' && keypad.ContainsKey(previousChar))
        {
            var characters = keypad[previousChar];
            output += characters[(count - 1) % characters.Length];
        }

        return output;
    }
}


