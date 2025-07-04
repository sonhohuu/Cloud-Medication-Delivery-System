﻿using FluentValidation;
using MediatR;
using Medication_Order_Service.Application.Behaviours;
using Medication_Order_Service.Application.Services;
using Medication_Order_Service.Domain.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static CSharpFunctionalExtensions.Result;

namespace Medication_Order_Service.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            // Register all FluentValidation validators from the current assembly
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IPasswordWrapper, PasswordWrapper>();
            services.AddScoped<IPasswordHasher<Account>, PasswordHasher<Account>>();
            services.AddScoped<ITokenHandlerService, TokenHandlerService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            // Register MediatR pipeline behavior for validation
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
