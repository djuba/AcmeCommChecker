using AcmeCommChecker.Factories;
using AcmeCommChecker.Models;
using NUnit.Framework;

namespace NUnitTestProject
{
    public class CommTypeCalendarEventFactoryTests
    {
        private CommTypeCalendarEventFactory factory { get; set; }

        [SetUp]
        public void Setup()
        {
            factory = new CommTypeCalendarEventFactory();
        }

        [Test]
        public void GetCommType_ReturnPhone()
        {
            var expected = CommTypeCalendarEvent.CommType.Phone.ToString();

            var projection = new OpenWeatherForecast.Projection()
            {
                main = new OpenWeatherForecast.Main()
            };

            // Should return phone anytime temp < 55
            projection.main.temp = 0;
            var result = factory.GetCommType(projection);
            Assert.AreEqual(expected, result);

            projection.main.temp = 54;
            result = factory.GetCommType(projection);
            Assert.AreEqual(expected, result);

            projection.main.temp = 55;
            result = factory.GetCommType(projection);
            Assert.AreNotEqual(expected, result);

            // Should return phone anytime it is raining
            projection.rain = new OpenWeatherForecast.Rain { _3h = 0.01f };

            projection.main.temp = 54;
            result = factory.GetCommType(projection);
            Assert.AreEqual(expected, result);

            projection.main.temp = 55;
            result = factory.GetCommType(projection);
            Assert.AreEqual(expected, result);

            projection.main.temp = 56;
            result = factory.GetCommType(projection);
            Assert.AreEqual(expected, result);

            projection.main.temp = 74;
            result = factory.GetCommType(projection);
            Assert.AreEqual(expected, result);

            projection.main.temp = 75;
            result = factory.GetCommType(projection);
            Assert.AreEqual(expected, result);

            projection.main.temp = 76;
            result = factory.GetCommType(projection);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetCommType_ReturnEmail()
        {
            var expected = CommTypeCalendarEvent.CommType.Email.ToString();

            var projection = new OpenWeatherForecast.Projection()
            {
                main = new OpenWeatherForecast.Main()
            };

            // Should return phone anytime 55 <= temp <= 75

            projection.main.temp = 54;
            var result = factory.GetCommType(projection);
            Assert.AreNotEqual(expected, result);

            projection.main.temp = 55;
            result = factory.GetCommType(projection);
            Assert.AreEqual(expected, result);

            projection.main.temp = 56;
            result = factory.GetCommType(projection);
            Assert.AreEqual(expected, result);

            projection.main.temp = 74;
            result = factory.GetCommType(projection);
            Assert.AreEqual(expected, result);

            projection.main.temp = 75;
            result = factory.GetCommType(projection);
            Assert.AreEqual(expected, result);

            projection.main.temp = 76;
            result = factory.GetCommType(projection);
            Assert.AreNotEqual(expected, result);
        }

        [Test]
        public void GetCommType_ReturnSMS()
        {
            var expected = CommTypeCalendarEvent.CommType.SMS.ToString();

            var projection = new OpenWeatherForecast.Projection()
            {
                main = new OpenWeatherForecast.Main()
            };

            // Should return phone anytime temp > 75

            projection.main.temp = 75;
            var result = factory.GetCommType(projection);
            Assert.AreNotEqual(expected, result);

            projection.main.temp = 76;
            result = factory.GetCommType(projection);
            Assert.AreEqual(expected, result);
        }
    }
}