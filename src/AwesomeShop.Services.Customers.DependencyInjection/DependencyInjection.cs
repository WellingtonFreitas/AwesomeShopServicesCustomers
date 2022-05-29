

using AwesomeShop.Services.Customers.Application.Commands.AddCustomer;
using AwesomeShop.Services.Customers.Application.Subscribers;
using AwesomeShop.Services.Customers.Data.Persistence;
using AwesomeShop.Services.Customers.Data.Persistence.Repositories;
using AwesomeShop.Services.Customers.Domain.Interfaces.MessageBus;
using AwesomeShop.Services.Customers.Domain.Interfaces.Repositories;
using AwesomeShop.Services.Customers.Infrastructure.MessageBus;
using Consul;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System;

namespace AwesomeShop.Services.Customers.DependencyInjection
{
    public static class DependencyInjection
    {


        public static void AddServicesDependenciesInjection(this IServiceCollection services, IConfiguration config)
        {
            services.AddMediatR(typeof(AddCustomerRequest));

            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                var address = config.GetSection("Consul:Host").Value;

                consulConfig.Address = new Uri(address);
            }));

        }

        public static void AddRepositoriesDependenciesInjection(this IServiceCollection services)
        {
            services.AddSingleton<IMongoDBContext, MongoDbContext>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }

        public static void AddMessageBus(this IServiceCollection services)
        {
            services.AddSingleton<IMessageBusClient, RabbitMqClient>();
            services.AddSingleton<IEventProcessor, EventProcessor>();
        }

        public static void AddSubscribers(this IServiceCollection services)
        {
            services.AddHostedService<CustomerCreatedSubscriber>();
        }

        public static void AddRabbitMq(this IServiceCollection services)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection("customers-service-producer");

            services.AddSingleton(new ProducerConnection(connection));
        }


        public static void UserConsul(this IApplicationBuilder app)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var lifeTime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

            var registration = new AgentServiceRegistration()
            {
                ID = $"customer-service",
                Name = "CustomerServices",
                Address = "localhost",
                Port = 5001
            };

            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

            lifeTime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            });

        }
    }
}