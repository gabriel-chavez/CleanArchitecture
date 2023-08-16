﻿using CleanArchitecture.Application.Contracts.Infraestructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Infraestructure.Persistence;
using CleanArchitecture.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infraestructure
{
    public static class InfraestructureServiceRegistration
    {
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContext<StreamerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConectionString"))
            );
            services.AddScoped(typeof(IAsyncRepositeory<>), typeof(RepositoryBase<>));
            services.AddScoped<IVideoRepository, IVideoRepository>();
            services.AddScoped<IStreamerRepository, StreamerRepository>();

            //services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            //services.AddTransient<IEmailService,EmailService>();
            return services;

        }
    }
}
