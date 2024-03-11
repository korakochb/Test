using System;
using System.Collections.Generic;

public class Test
{
    private static Dictionary<char, int> symbolValues = new Dictionary<char, int>()
    {
        {'A', 1},
        {'B', 5},
        {'Z', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'R', 1000}
    };

    public static int ConvertToInteger(string input)
    {
        int result = 0;

        for (int i = 0; i < input.Length; i++)
        {
            char currentInputAlphabet = input[i];
            int currentValue = symbolValues[input[i]];

            if (i + 1 < input.Length)
            {
                char nextInputAlphabet = input[i + 1];
                switch (currentInputAlphabet)
                {
                    case 'A':
                        if (nextInputAlphabet == 'B' || nextInputAlphabet == 'Z')
                            result -= currentValue;
                        else
                            result += currentValue;
                        break;
                    case 'Z':
                        if (nextInputAlphabet == 'L' || nextInputAlphabet == 'C')
                            result -= currentValue;
                        else
                            result += currentValue;
                        break;
                    case 'C':
                        if (nextInputAlphabet == 'D' || nextInputAlphabet == 'R')
                            result -= currentValue;
                        else
                            result += currentValue;
                        break;
                    default:
                        result += currentValue;
                        break;
                }
            }
            else
                result += currentValue;

        }

        return result;
    }

    public static void Main(string[] args)
    {
       var input = "RCRZCAB";

       Console.WriteLine("Input : " + input);
       Console.WriteLine("Output : " + ConvertToInteger(input));
    }
}