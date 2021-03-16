﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuApp.PaymentService.Logic.Entities;
using MenuApp.PaymentService.Logic.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MenuApp.PaymentService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IForecastRepository _forecastRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IForecastRepository forecastRepository)
        {
            _logger = logger;
            _forecastRepository = forecastRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await _forecastRepository.GetALl();
            var rng = new Random();
            return Enumerable.Range(0, 7).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index).DayOfWeek.ToString(),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}