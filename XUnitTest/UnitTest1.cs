using Tranform.Try;
using FluentAssertions;
using NSubstitute;
using FluentAssertions.Extensions;
using XUnitTest.Services;
using XUnitTest.IServices;
using FakeItEasy;

namespace XUnitTest
{
    public class UnitTest1
    {
        private readonly NetworkServices _networkServices;
        private readonly Calculator _tus;
        private readonly IServices.IServices _servicess;
        public UnitTest1()
        {
            _tus = new Calculator();
            _servicess = A.Fake<IServices.IServices>();

        }

        [Fact]
        public void Iservices_Runining_Return()
        {
           A.CallTo(()=>_servicess.IsRunning()).Returns(true);
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
            var result = new NetworkServices(_servicess);
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
    private readonly IServices _services;
    public NetworkServices(IServices services)
    {
        _services = services;
    }

    public DateTime LastPingDate()
    {
        return DateTime.Now;
    }

    //
    public string IsRunings()
    {
        if (_services.IsRunning())
        {
            return "The services is runing";
        }
        else
        {
            return "The services is not runing";
        }
        
    }
}