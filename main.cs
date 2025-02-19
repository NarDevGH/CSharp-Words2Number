using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
public class Parser
{
    static Dictionary<string, int> numbersDict = new Dictionary<string, int> {{ "one", 1 }, { "two", 2 }, { "three", 3 },
      { "four", 4 }, { "five", 5 }, { "six", 6 }, { "seven", 7 }, { "eight", 8 }, { "nine", 9 },
      { "ten", 10 }, { "eleven", 11 }, { "twelve", 12 }, { "thirteen", 13 }, { "fourteen", 14 },
      { "fifteen", 15 }, { "sixteen", 16 }, { "seventeen", 17 }, { "eighteen", 18 }, { "nineteen", 19 },
      { "twenty", 20 }, { "thirty", 30 }, { "fourty", 40 }, { "forty", 40 }, { "fifty", 50 },
      { "sixty", 60 },{ "seventy", 70 }, { "eighty", 80 }, { "ninety", 90 } };


    public static int ParseInt(string s)
    {
        if (s == "zero")
            return 0;

        if (s == "one million")
            return 1000000;

        s = s.Replace(" and", "").Replace("-", " ");
        string[] numbers = s.Split();
        var hundreds = new List<int> { 0 };

        foreach (string number in numbers)
        {
            if (number == "hundred")
                hundreds[^1] *= 100;

            else if (number == "thousand")
            {
                hundreds[0] *= 1000;
                hundreds.Add(0);
            }

            else hundreds[^1] += numbersDict[number];
        }

        return hundreds.Sum();
    }
}