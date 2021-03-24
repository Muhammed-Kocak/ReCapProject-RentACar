using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static ILifetimeScope AutofacServiceProvider { get; private set; }
        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }

        public static ILifetimeScope AutofacCreate(IServiceProvider services)
        {
            AutofacServiceProvider = services.GetAutofacRoot();
            return AutofacServiceProvider;
        }
    }
}
