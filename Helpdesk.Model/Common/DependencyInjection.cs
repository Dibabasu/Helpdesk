using AutoMapper;

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Helpdesk.Model.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddModels(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}