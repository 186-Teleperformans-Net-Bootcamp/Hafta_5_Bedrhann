using Hafta._5.Application.Interfaces.EventServices;
using Hafta._5.Infrastructure.Services.EventService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta._5.Infrastructure
{
    public static class ServicesRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<ICreateUserEvent,CreateUserEvent>();
        }
    }
}
