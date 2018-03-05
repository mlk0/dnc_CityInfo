using System;
using Microsoft.Extensions.Logging;

namespace CityInfoApi.Services
{
    public class EmailService : IEmailService
    {
        private ILogger<EmailService> _logger;
        private string _fromEmail = "noreply@app.com";
        private string _toEmail = "SomeDev@company.com";

        public EmailService(ILogger<EmailService> logger)
        {
            this._logger = logger;
        }

        public void SendEmail(){
            _logger.LogInformation($"Sending Email to : {_toEmail}, from : {_fromEmail}");
            
        }
    }
}
