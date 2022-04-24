using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Locators;

public class Services
{
    public static void PrintElements(ReadOnlyCollection<IWebElement> elements, string cssName)
    {
        Console.WriteLine($"Found {elements.Count} elements with CSS {cssName}:");
        for (int i = 0; i < elements.Count; i++)
        {
            Console.WriteLine("{0,3}. {1}", i + 1, elements[i]);
        }
        
        Console.WriteLine();
    }
}
