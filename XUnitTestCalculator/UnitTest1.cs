using BLL.Interfaces;
using DAL.Interfaces;
using Moq;
using System;
using Xunit;

namespace XUnitTestCalculator
{
    public class UnitTest1
    {
        private readonly Mock<ICalculatorRepository> mockrepo;

        public UnitTest1()
        {
            mockrepo = new Mock<ICalculatorRepository>();
        }

        [Theory]
        [InlineData("5+2", "7")]
        [InlineData("50+25", "75")]
        [InlineData("20+5", "25")]
        [InlineData("12+3", "15")]
        public void TestAdd(string test, string expected)
        {
            var calcService = new CalculatorService(mockrepo.Object);
            var result = calcService.Calculate(test);
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData("50-25", "25")]
        [InlineData("25-50", "-25")]
        [InlineData("30-100", "-70")]
        [InlineData("1-2", "-1")]
        public void TestSubstract(string test, string expected)
        {
            var calcService = new CalculatorService(mockrepo.Object);
            var result = calcService.Calculate(test);
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData("10*5", "50")]
        [InlineData("2000*5", "10000")]
        [InlineData("1*25", "25")]
        [InlineData("14*78", "1092")]
        public void TestMultiply(string test, string expected)
        {
            var calcService = new CalculatorService(mockrepo.Object);
            var result = calcService.Calculate(test);
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData("10/5", "2")]
        [InlineData("50/50", "1")]
        [InlineData("1/2", "0,5")]
        [InlineData("80/8", "10")]
        public void TestDevide(string test, string expected)
        {
            var calcService = new CalculatorService(mockrepo.Object);
            var result = calcService.Calculate(test);
            Assert.Equal(result, expected);
        }
    }
}
