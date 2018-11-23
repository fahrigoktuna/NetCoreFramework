using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreFramework.Infrastructure.Helpers.RabbitMQ
{
    public class RabbitMqOptions
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string VirtualHost { get; set; }

        public string HostName { get; set; }
    }
}
