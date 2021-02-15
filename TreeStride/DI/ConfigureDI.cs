using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tree.Data.Contract;
using Tree.Data.Data;
using Tree.Data.Repositories;
using Tree.Data.Repositories.Transaction.UnitOfWork;

namespace Tree.DI
{
    public static class ConfigureDI
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            #region[Services]
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddMediatR(AppDomain.CurrentDomain.Load("Tree.Service"));
            #endregion

            #region[Database]
            services.AddDbContext<DataContext>(options => options.UseMySQL(configuration.GetConnectionString("Database")));
            #endregion

            #region[Repositories]
            services.AddTransient<IDeviceRepository, DeviceRepository>();
            services.AddTransient<IRegionRepository, RegionRepository>();
            services.AddTransient<ISensorReadingRepository, SensorReadingRepository>();
            #endregion
        }
    }
}
