using System;

namespace AncientMonkey;

internal class TextManager
{
    public static string ConvertCostText(long number)
    {
        string text = "0";
        if (number < 1000000)
        {
            text = number.ToString();
        }
        if (number >= 10000)
        {
            text = MathF.Round(number / 1000) + "K";
        }
        if (number >= 1000000)
        {
            text = MathF.Round(number / 100000) / 10 + "M";
        }
        if (number >= 1000000000)
        {
            text = MathF.Round(number / 100000000) / 10 + "B";
        }
        return text;
    }
}
