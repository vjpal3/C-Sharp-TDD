using System;
using NUnit.Framework;
using AdvancedTDD.TestDoubles;

namespace AdvancedTdd.Tests.TestDoubles
{
    [TestFixture]
    class CustomerTests
    {
        [Test]
        public void CalculateWage_HourlyPaid_ReturnsCorrectValue()
        {
            DbGatewayStub gateway = new DbGatewayStub();
            gateway.SetWorkingStatistic(new WorkingStatistics()
            {
                PayHourly = true, HourSalary = 100, WorkingHours = 10
            });

            var sut = new Customer(new LoggerDummy(), gateway);

            const int anyId = 1;
            decimal actual = sut.CalculateWage(anyId);

            const decimal expectedWage = 100 * 10;
            Assert.That(actual, Is.EqualTo(expectedWage).Within(0.1));

        }

        [Test]
        public void CalculateWage_PassesCorrectId()
        {
            const int id = 1;
            var gatewaySpy = new DbGatewaySpy();

            var sut = new Customer(new LoggerDummy(), gatewaySpy);
            gatewaySpy.SetWorkingStatistics(new WorkingStatistics());
            sut.CalculateWage(id);
            Assert.That(1, Is.EqualTo(gatewaySpy.Id));
        }


    }
}
