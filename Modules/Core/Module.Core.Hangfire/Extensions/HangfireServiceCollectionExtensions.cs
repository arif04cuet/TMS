﻿using System;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Module.Core.Hangfire.Internal;
using Module.Core.Hangfire.Services;

namespace Module.Core.Hangfire.Extensions
{
    /// <summary>
    /// Extensions for Hangfire Service.
    /// </summary>
    public static class HangfireServiceCollectionExtensions
    {
        /// <summary>
        /// Adds Hangfire Service extensions.
        /// </summary>
        public static IServiceCollection AddHangfireService(this IServiceCollection services) => AddHangfireService(services, null);

        /// <summary>
        /// Adds Hangfire contrib extensions and configures Hangfire with the specified <see cref="IGlobalConfiguration"/> action.
        /// </summary>
        public static IServiceCollection AddHangfireService(this IServiceCollection services, Action<IGlobalConfiguration> configAction)
        {
            services.AddSingleton(services);

            services.AddHangfire(c =>
            {
                configAction?.Invoke(c);
            });

            services.AddTransient<IBackgroundJobManager, BackgroundJobManager>();
            services.AddSingleton<BackgroundJobCollection>();

            return services;
        }
    }
}
