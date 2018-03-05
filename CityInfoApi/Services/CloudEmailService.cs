using System;
using Microsoft.Extensions.Logging;

namespace CityInfoApi.Services
{
    public class CloudEmailService : IEmailService
    {
        private ILogger<CloudEmailService> _logger;
        //private string _fromEmail = "noreply@app.com";
        //private string _toEmail = "SomeDev@company.com";

        private string _fromEmail = Program.AppConfiguration["MailSettings:fromEmail"];
        private string _toEmail = Program.AppConfiguration["MailSettings:toEmail"];


        public CloudEmailService(ILogger<CloudEmailService> logger)
        {
            this._logger = logger;
        }

        public void SendEmail(){
            _logger.LogInformation($"Sending CLOUD Email to : {_toEmail}, from : {_fromEmail}");

            
        }
    }
}
