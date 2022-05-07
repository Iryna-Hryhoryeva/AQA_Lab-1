using System;
using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;
using NUnit_TestProject.ClassesUnderTest;
using NUnit_TestProject.Exceptions;
using NUnit_TestProject.Utils;
using Should;

namespace NUnit_TestProject.Tests;

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
    public void Div_AssertMultipleIsTrue_Success()
    {
        Assert.Multiple(() =>
        {
            string futureInt = null!;
            Assert.IsNull(futureInt);
            Assert.Null(futureInt);
            futureInt = "";
            Assert.IsEmpty(futureInt);
            futureInt = "5";
            Assert.IsNotEmpty(futureInt);

            var realInt = Convert.ToInt16(futureInt);
            Assert.AreEqual(realInt, _calculator.Div(10, 2), "Division is incorrect.");
            Assert.AreEqual(realInt, _calculator.Div(-10, -2), "Division is incorrect.");
            Assert.AreEqual(realInt * -1, _calculator.Div((int) 10.24, -2), "Division is incorrect.");
            Assert.DoesNotThrow(() => { _calculator.Div(10, 10); });
            Assert.Throws<DivideByZeroException>(delegate { _calculator.Div(10, 0); },
                "Division by zero is prohibited.");

            var customException = Assert.Throws<CustomException>(delegate
            {
                throw new CustomException("Custom exception message.");
            });
            Assert.That(customException.Message, Is.EqualTo("Custom exception message."));
        });
    }

    [Test]
    [Category("Integer division")]
    [Property("Severity", "E")]
    public void Div_ThrowsOverflowException_If_ResultIsOutsideIntRange()
    {
        var result = 0;

        try
        {
            var greaterRandomIntValue = Randomizer.GetGreaterRandomIntValue();
            var lesserRandomIntValue = Randomizer.GetLesserRandomIntValue();
            result = _calculator.Div(greaterRandomIntValue, lesserRandomIntValue);
        }
        catch
        {
            if (result < Int32.MinValue || result > Int32.MaxValue)
            {
                Assert.Throws<OverflowException>(() => result.ShouldNotBeInRange(Int32.MinValue, Int32.MaxValue));
            }
        }
    }

    [Test]
    [Category("Integer division")]
    [Property("Severity", "A")]
    public void Div_Success_IfNoFractionalPart()
    {
        var lesserRandomIntValue = Randomizer.GetLesserRandomIntValue();
        var greaterRandomIntValue = Randomizer.GetGreaterRandomIntValue();
        var result = _calculator.Div(lesserRandomIntValue, greaterRandomIntValue);
        Assert.Less(lesserRandomIntValue, greaterRandomIntValue);

        if (lesserRandomIntValue < greaterRandomIntValue)
        {
            Assert.AreEqual(0, result, "An integer must have no fractional part.");
        }

        Assert.Pass("Asserted that test's passed.");
    }

    [Ignore("Contains bug in Assert.AreSame.")]
    [Test]
    [Category("Integer division")]
    public void TestDivWithListOfInts()
    {
        var listOfInts = new List<int> {3, 5, 8, 10, 4, 4};
        Assert.Contains(3, listOfInts);
        Assert.AreNotSame(listOfInts[0], listOfInts[1]);
        Assert.IsNotEmpty(listOfInts);
        Assert.NotNull(listOfInts[5]);
        Assert.LessOrEqual(4, listOfInts[1]);
        Assert.AreEqual(2, _calculator.Div(listOfInts[2], listOfInts[4]));

        Assert.Fail("Expected: same as 4 \n  But was:  4");
        Assert.AreSame(listOfInts[4], listOfInts[5]);
    }

    [Test]
    [Category("Double division")]
    public void DivWithComplexNumber()
    {
        var complexNumber = new Complex(double.MaxValue, double.Epsilon);
        Assert.AreNotEqual(0, _calculator.Div(complexNumber.Real, complexNumber.Imaginary));
    }

    [Test]
    [Category("Double division")]
    public void When_EachAssertionInAssertMultipleIsTrue_Expect_Success()
    {
        Assert.Multiple(() =>
        {
            var greaterRandomDoubleValue = Randomizer.GetGreaterRandomDoubleValue();
            var lesserRandomDoubleValue = Randomizer.GetLesserRandomDoubleValue();
            Assert.GreaterOrEqual(greaterRandomDoubleValue, lesserRandomDoubleValue);
            TestContext.Out.WriteLineAsync("First double is " + greaterRandomDoubleValue + ".");
            TestContext.Out.WriteLineAsync($"Second double is {lesserRandomDoubleValue}.");
            Assert.AreEqual(greaterRandomDoubleValue / lesserRandomDoubleValue,
                _calculator.Div(greaterRandomDoubleValue, lesserRandomDoubleValue));
            Assert.False(_calculator.Div(lesserRandomDoubleValue, greaterRandomDoubleValue) > 1);

            Assert.AreNotEqual(5.346d, _calculator.Div(4.902, 7.12));
            Assert.True(double.IsPositiveInfinity(_calculator.Div(10d, 0d)));
            Assert.IsTrue(double.IsNegativeInfinity(_calculator.Div(-10d, 0d)));
            Assert.IsFalse(double.IsInfinity(_calculator.Div(0d, 0d)));
            Assert.IsNaN(_calculator.Div(Math.Sqrt(-4), 2));
        });
    }

    [Test]
    [Category("Double division")]
    public void Should_BeIgnored_If_IsDuplicate()
    {
        Assert.Multiple(() =>
        {
            var greaterRandomDoubleValue = Randomizer.GetGreaterRandomDoubleValue();
            var lesserRandomDoubleValue = Randomizer.GetLesserRandomDoubleValue();
            Assert.GreaterOrEqual(greaterRandomDoubleValue, lesserRandomDoubleValue);
            TestContext.Out.WriteLineAsync("First double is " + greaterRandomDoubleValue + ".");
            TestContext.Out.WriteLineAsync($"Second double is {lesserRandomDoubleValue}.");
            Assert.AreEqual(greaterRandomDoubleValue / lesserRandomDoubleValue,
                _calculator.Div(greaterRandomDoubleValue, lesserRandomDoubleValue));
            Assert.False(_calculator.Div(lesserRandomDoubleValue, greaterRandomDoubleValue) > 1);

            Assert.AreNotEqual(5.346d, _calculator.Div(4.902, 7.12));
            Assert.True(double.IsPositiveInfinity(_calculator.Div(10d, 0d)));
            Assert.IsTrue(double.IsNegativeInfinity(_calculator.Div(-10d, 0d)));
            Assert.IsFalse(double.IsInfinity(_calculator.Div(0d, 0d)));
            Assert.IsNaN(_calculator.Div(Math.Sqrt(-4), 2));
        });
        Assert.Ignore("Duplicate of When_EachAssertionInAssertMultipleIsTrue_Expect_Success.");
    }

    [Test]
    public void InconclusiveAssert()
    {
        Assert.Inconclusive("This functionality is not implemented yet.");
    }

    [TearDown]
    public void TearDown()
    {
        Console.WriteLine("The test is complete.");
    }

    [OneTimeTearDown]
    public void EndTesting()
    {
        Console.Out.WriteLine("The testing is over!");
    }
}
