using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NUnit_TestProject;

[TestFixture]
public class Tests
{
    private Calculator _calculator;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _calculator = new Calculator(); 
    }

    [SetUp]
    public void Setup()
    {
        Console.Out.WriteLine("Setup method is running...");
    }

    [Test]
    [Category("Integer division")]
    [Property("Severity", "A")]
    public void TestIntDiv()
    {
        Assert.Multiple(() =>
        {
            Assert.AreEqual(5, _calculator.Div(10, 2), "Division is incorrect");
            Assert.AreEqual(5, _calculator.Div(-10, -2), "Division is incorrect");
            Assert.AreEqual(-5, _calculator.Div((int)10.24, -2), "Division is incorrect");
            Assert.Throws<DivideByZeroException>(delegate { _calculator.Div(10, 0); }, "Division by zero is prohibited");
        });
    }

    [Test]
    [Category("Integer division")]
    [Property("Severity", "A")]
    public void TestForNoFractionalPart()
    {
        var a = TestContext.CurrentContext.Random.Next(0, 100);
        var b = TestContext.CurrentContext.Random.Next(101, 200);
        var result = _calculator.Div(a, b);
        if (a < b)
        {
            Assert.AreEqual(0, result, "An integer must have no fractional part");
        }
    }

    [Test]
    [Category("Integer division")]
    public void TestIntegerArray()
    {
        var intCollection = new List<int> {3, 5, 8, 10, 4};
        Assert.Contains(3, intCollection);
        Assert.AreNotSame(intCollection[0], intCollection[1]);
        Assert.IsNotEmpty(intCollection);
        Assert.AreEqual(2, _calculator.Div(intCollection[2], intCollection[4]));
    }
    
    [Test]
    [Category("Double division")]
    public void TestDoubleDiv()
    {
        Assert.Multiple(() =>
        {
            var a = TestContext.CurrentContext.Random.NextDouble(100);
            var b = TestContext.CurrentContext.Random.NextDouble(10, 20);

            TestContext.Out.WriteLineAsync("First Double is " + a);
            TestContext.Out.WriteLineAsync($"Second Double is {b}");
            Assert.AreEqual(a / b, _calculator.Div(a, b));
            Assert.AreNotEqual(5.346d, _calculator.Div(4.902, 7.12));
            Assert.True(Double.IsPositiveInfinity(_calculator.Div(10d, 0d)));
            Assert.IsTrue(Double.IsNegativeInfinity(_calculator.Div(-10d, 0d)));
            Assert.IsFalse(Double.IsInfinity(_calculator.Div(0d, 0d)));
            Assert.IsNaN(_calculator.Div(Math.Sqrt(-4), 2));
                
        });
    }
    
    [TearDown]
    public void EndTesting()
    {
        Console.Out.WriteLine("The testing is over!");
    }
}
