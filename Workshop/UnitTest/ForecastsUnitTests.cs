using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Workshop.Controllers;
using Workshop.Helpers;
using System.Linq;

namespace Workshop
{
    [TestClass]
    public class ForecastsUnitTests
    {
        [TestMethod]
        public void WeatherForecastController_GetForecasts_GetExpectedFromMethod()
        {
            //.NET Service Provider
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();

            //Logger Factory for Controller Constructor
            var factory = serviceProvider.GetService<ILoggerFactory>();

            //Mocked Class
            var mockedTools = new Moq.Mock<Tools>();

            //List to insert into test
            var weatherList = new List<WeatherForecast>();
            weatherList.Add(new WeatherForecast()
            {
                Date = DateTime.Now,
                Summary = "test",
                TemperatureC = 34
            });

            mockedTools.Setup(r => r.GetRandomForecasts()).Returns(weatherList);

            //Class Controller to Test with mocked Tools
            var mockedController = new WeatherForecastController(factory.CreateLogger<WeatherForecastController>(), mockedTools.Object);


            var receivedList = mockedController.GetForecasts().ToList();

            
            //Test if is the item we expected
            CollectionAssert.AreEqual(weatherList, receivedList);

            var wrongWeatherList = new List<WeatherForecast>();
            wrongWeatherList.Add(new WeatherForecast()
            {
                Date = DateTime.Now,
                Summary = "test2",
                TemperatureC = 35
            });

            CollectionAssert.AreNotEqual(wrongWeatherList, receivedList);
        }
    }
}
