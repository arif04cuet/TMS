﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Module.Core.Hangfire.Models
{
    public abstract class BackgroundJob<TArgs> : IBackgroundJob<TArgs>
    {
        public ILogger<BackgroundJob<TArgs>> Logger { get; set; }

        protected BackgroundJob()
        {
            Logger = NullLogger<BackgroundJob<TArgs>>.Instance;
        }

        public abstract void Execute(TArgs args);
    }
}