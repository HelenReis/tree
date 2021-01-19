using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tree.Data.Contract;
using Tree.Data.Repositories;
using Tree.Data.Repositories.Transaction.UnitOfWork;

namespace Tree.DI
{
    public static class ConfigureDI
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IDeviceRepository, DeviceRepository>();
            services.AddTransient<IRegionRepository, RegionRepository>();
            // Serviços
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
