using System;
using NUnit.Framework;
using NUnit_TestProject.ClassesUnderTest;
using NUnit_TestProject.Data;
using Should;

namespace NUnit_TestProject.Tests
{
    public class TestCaseDataTests
    {
        private Calculator _calculator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _calculator = new Calculator();
        }

        [Category("Integer division")]
        [TestCaseSource(typeof(DataForTestCases), nameof(DataForTestCases.TestCases))]
        public int TestDivWithIntNumbers(int numenator, int denominator)
        {
            var result = _calculator.Div(numenator, denominator);

            return result;
        }

        [Category("Integer division")]
        [TestCase(-1, 0)]
        public void TestDivThrowsExceptionIfDenominatorIsZeroAndNumbersAreInt(int numenator, int denominator)
        {
            Assert.That(() => _calculator.Div(numenator, denominator), Throws.TypeOf<DivideByZeroException>());
        }

        [Category("Integer division")]
        [TestCase(1, 1)]
        [TestCase(12345, 6)]
        [TestCase(10, 5)]
        public void Div_PositiveNumbers_ResultShouldBePositive(int numenator, int denominator)
        {
            var result = _calculator.Div(numenator, denominator);
            result.ShouldBeGreaterThan(0);
        }
    }
}
