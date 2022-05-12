using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace PageObject.Utils;

public class Randomizer
{
    public static int GetRandomIndex(List<IConfigurationSection> listOfValues)
    {
        return Random.Shared.Next(listOfValues.Count - 1);
    }
}
