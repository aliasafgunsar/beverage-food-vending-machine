using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using VendingMachine.Core.Interfaces;
using VendingMachine.Infrastructure.Repositories;
using VendingMachine.Infrastructure.Services;

namespace VendingMachine.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IVendingMachineService, VendingMachineService>();

            return services;
        }
    }
}
