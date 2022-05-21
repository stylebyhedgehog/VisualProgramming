using System;
using System.Collections.Generic;

public class ScorePattern
{
    private static Dictionary<int, string> rankLetter = new Dictionary<int, string>()
    {
        {0,"" },
        {1,"A" },
        {2,"B" },
        {3,"C" },
        {4,"D" },
        {5,"E" },
        {6,"F" },
        {7,"G" },
        {8,"H" },
        {9,"I" },
        {10,"J" },
        {11,"K" },
        {12,"L" },
        {13,"M" },
    };
    public static string ConvertToString(int value)
    {
        int rank = NumberRank(value);
        string letter = rankLetter[NumberRank(value)];
        if (rank == 0)
        {
            return value.ToString();
        }
        return Round2(value / (1000.0d * rank)).ToString() + letter;
    }

    private static double Round2(double value)
    {
        return Math.Round(value, 1);
    }

    private static int NumberRank(int value)
    {
        int calculatedValue = value;
        int rank = 0;
        while (calculatedValue >= 1000)
        {
            calculatedValue /= 1000;
            rank += 1;
        }
        return rank;
    }
}
