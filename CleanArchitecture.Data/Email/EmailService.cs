using CleanArchitecture.Application.Contracts.Infraestructure;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Infraestructure.Email;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.Email
{
    public class EmailService : IEmailService
    {
      //  public EmailSettings _emailSettings { get; set; }
        public ILogger<EmailService> _logger { get; }

        public EmailService(ILogger<EmailService> logger
            //, EmailSettings emailSettings
            )
        {
            _logger = logger;
            //_emailSettings = emailSettings;
        }

        public async Task<bool> SendEmail(Application.Models.Email email)
        {
            return true;
        }
    }
}
