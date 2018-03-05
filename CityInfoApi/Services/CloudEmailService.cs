using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CityInfoApi.Services
{
    public class CloudEmailService : IEmailService
    {
        private ILogger<CloudEmailService> _logger;
        //private string _fromEmail = "noreply@app.com";
        //private string _toEmail = "SomeDev@company.com";
        private IConfiguration _config;

        //private string _fromEmail = Program.AppConfiguration["MailSettings:fromEmail"];
        //private string _toEmail = Program.AppConfiguration["MailSettings:toEmail"];

        private string _fromEmail;
        private string _toEmail;

        public CloudEmailService(ILogger<CloudEmailService> logger, IConfiguration config)
        {
            this._logger = logger;
            this._config = config;

            this._fromEmail = this._config["MailSettings:fromEmail"];
            this._toEmail = this._config["MailSettings:toEmail"];

        }

        public void SendEmail(){
            _logger.LogInformation($"Sending CLOUD Email to : {_toEmail}, from : {_fromEmail}");

            
        }
    }
}
