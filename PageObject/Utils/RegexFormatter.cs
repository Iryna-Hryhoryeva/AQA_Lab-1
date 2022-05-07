using System;
using System.Text.RegularExpressions;

namespace PageObject.Utils;

public class RegexFormatter
{
    private static string _pattern;
    private static string _target;
    private static Regex _regex;

    public static double RemoveOddCharsAndMakeDouble(string price)
    {
        _pattern = @"[a-z]*\:*\s*\$*";
        _target = "";
        _regex = new Regex(_pattern);
        var priceWithADot = _regex.Replace(price, _target);

        _pattern = @"\.";
        _target = ",";
        _regex = new Regex(_pattern);
        var priceWithAComma = _regex.Replace(priceWithADot, _target);

        return Convert.ToDouble(priceWithAComma);
    }

    public static string GetOnlyNumbersAsStringFrom(string id)
    {
        _pattern = @"\D";
        _target = "";
        _regex = new Regex(_pattern);

        return _regex.Replace(id, _target);
    }
}
