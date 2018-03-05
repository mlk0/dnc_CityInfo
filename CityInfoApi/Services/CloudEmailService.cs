using System;
using Microsoft.Extensions.Logging;

namespace CityInfoApi.Services
{
    public class CloudEmailService : IEmailService
    {
        private ILogger<CloudEmailService> _logger;

        public CloudEmailService(ILogger<CloudEmailService> logger)
        {
            this._logger = logger;
        }

        public void SendEmail(){
            _logger.LogInformation("Sending CLOUD Email");
            
        }
    }
}
