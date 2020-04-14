using System;
using Module.Core.Hangfire.Services;
using Msi.UtilityKit;

namespace Module.Core.Hangfire.Extensions
{
    /// <summary>
    /// Some extension methods for <see cref="IBackgroundJobManager"/>.
    /// </summary>
    public static class BackgroundJobManagerExtensions
    {
        /// <summary>
        /// Enqueues a job to be executed.
        /// </summary>
        /// <typeparam name="TArgs">Type of the arguments of job.</typeparam>
        /// <param name="backgroundJobManager">Background job manager reference</param>
        /// <param name="args">Job arguments.</param>
        /// <param name="delay">Job delay (wait duration before first try).</param>
        public static string Enqueue<TArgs>(this IBackgroundJobManager backgroundJobManager, TArgs args, TimeSpan? delay = null)
        {
            return AsyncUtilities.RunSync(() => backgroundJobManager.EnqueueAsync(args, delay));
        }
    }
}
