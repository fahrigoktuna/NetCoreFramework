using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreFramework.Domain.Events.Interface;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreFramework.Infrastructure.Helpers.RabbitMQ
{
    public static class Extensions
    {
        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                HostName = options.HostName,
                Password = options.Password,
                VirtualHost = options.VirtualHost,
                UserName = options.UserName
            };
            services.AddSingleton<IConnection>(_ => connectionFactory.CreateConnection());
        }

        public static void PublishEvent<TEvent>(this IConnection con, TEvent @event, string queueName) where TEvent : IDomainEvent
        {
            using (var channel = con.CreateModel())
            {
                channel.QueueDeclare(queueName, false, false, false, null);

                var tempMessage = JsonConvert.SerializeObject(@event);

                channel.BasicPublish("", queueName, null, Encoding.UTF8.GetBytes(tempMessage));
            }

        }
    }
}
