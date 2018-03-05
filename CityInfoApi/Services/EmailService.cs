using System;
using Microsoft.Extensions.Logging;

namespace CityInfoApi.Services
{
    public class EmailService
    {
        private ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            this._logger = logger;
        }

        public void SendEmail(){
            _logger.LogInformation("Sending Email");
            
        }
    }
}
