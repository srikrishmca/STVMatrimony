using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STVMatrimonyAPI.Services
{
    public class MailService
    {
        private readonly IOptions<Model.EMailConfiguration> _emailConfiguration;
        public MailService(IOptions<Model.EMailConfiguration> emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }
    }
}
