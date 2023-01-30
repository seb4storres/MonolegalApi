using EmailService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monolegal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IEmailSender _emailSender;


        public WeatherForecastController(IEmailSender emailSender)
        {

            _emailSender = emailSender;
        }

        [HttpPut]
        public IEnumerable<WeatherForecast> Put()
        {
            var message = new Message(new string[] { "torresjuansebas@gmail.com" }, "Pago Factura", "Señor ususario, su factura a cambiado de estado de pago, se le solicita el pronto pago de esta");
            _emailSender.SendEmail(message);


            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
