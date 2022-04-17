using System;

namespace Selenium;

public class Services
{
    public static void SayCongratulationsOrSorry(bool testPassed)
    {
        Console.Out.WriteLineAsync(testPassed ? "Yay, test passed :) " : "Test failed :( ");
    }
}
