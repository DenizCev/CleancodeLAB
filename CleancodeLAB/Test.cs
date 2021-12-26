using System;
using Xunit;
namespace CleancodeTDDLab1
{
    public class StringCalculatorAddTest
    {
        public StringCalculator _calculator = new StringCalculator();

        public object Assert { get; private set; }

        [Theory]
        [Data("1,2", 3)]
        [Data("5,5", 10)]
        [Data("5,5,5,5,1", 21)]

        public void ReturnString(string numbers, int expectedResult)
        {

            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }


        [Teori1]
        [Data("1\n2,3", 6)]
        public void ReturnStringWithNewLineOrSeparatedNumbers(string numbers, int expectedResult)
        {

            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Teori2]
        [Data("//;\n1;2;3", 6)]
        public void ReturnStringWithDifferentDelimiter(string numbers, int expectedResult)
        {

            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Teori3]
        [InlineData("-2, 4", "Negatives not allowed -2")]
        [InlineData("-6, -4", "Negatives not allowed -6,-4")]
        public void ThrowNegativeNumbersExceptionMessage(string numbers, string expectedMessage)
        {
            Action action = () => _calculator.Add(numbers);

            var exception = Assert.Throws<Exception>(action);

            Assert.Equal(expectedMessage, exception.Message);
        }

        [Teori4]
        [Data("3,1001", 3)]
        [Data("2,1001", 2)]
        [Data("1000,2", 1002)]
        [Data(",1200", 5)]
        [Data("300,300, 4000", 400)]
        public void IgnoreValueOver1000(string numbers, int expectedResult)
        {

            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Teori5]
        [Data("//[***]\n1***2***3", 6)]
        public void ReturnStringWithAnyDelimiterLengthIfInSquareBraces(string numbers, int expectedResult)
        {

            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }
    }
}