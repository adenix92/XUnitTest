using Tranform.Try;
using FluentAssertions;
using NSubstitute;
using FluentAssertions.Extensions;

namespace XUnitTest
{
    public class UnitTest1
    {
        private readonly Calculator _tus;
        public UnitTest1()
        {
            _tus = new Calculator();

        }

        static int sumTwoDigit(int[] digit)
        {
            int sum = 0;
            for (int i = 0; i < digit.Length; i++)
            {
                sum += digit[i];
            }
            return sum;
        }

        [Fact]
        public void MathematicalTesting()
        {
            _tus.Add(12, 2);


        }

        public int sumTwoNumber(int a, int b)
        {
            return a + b;
        }

        [Theory]
        [InlineData(new int[]{2,3,4,5},14)]
        public void sumTwoNumber_ReturnResult(int[] a, int c)
        {
            //arrange

            //act
            var result = sumTwoDigit(a);
            Assert.Equal(c, result);
            result.Should().Be(result);
            //result.Should().BeGreaterThan(5);
            
        }

        public DateTime checkDateTime() { return DateTime.Now; }

        [Fact]
        public void checkDateTime_ReturnofDate()
        {
            //arrange
            var result = new NetworkServices();
            //act
            var s = result.LastPingDate();
            //assert
            s.Should().BeAfter(1.January(2010));
            s.Should().BeBefore(1.January(2030));
        }

       
    }
}

public class NetworkServices
{
    public DateTime LastPingDate()
    {
        return DateTime.Now;
    }
}