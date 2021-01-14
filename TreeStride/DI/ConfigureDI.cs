using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TreeStride.Data.Contract;
using TreeStride.Data.Repositories;
using TreeStride.Data.Repositories.Transaction.UnitOfWork;

namespace TreeStride.DI
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
