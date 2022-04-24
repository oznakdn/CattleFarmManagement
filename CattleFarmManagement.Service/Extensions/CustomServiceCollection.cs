using CattleFarmManagement.Data.Context;
using CattleFarmManagement.Data.Repositories.Abstract.AbstractBase;
using CattleFarmManagement.Data.Repositories.Concrete.ConcreteBase;
using CattleFarmManagement.Service.Abstract;
using CattleFarmManagement.Service.Concrete;
using CattleFarmManagement.Service.Mappings.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CattleFarmManagement.Service.Extensions
{
    public static class CustomServiceCollection
    {
        public static IServiceCollection AddCustomService(this IServiceCollection services, string connectionString)
        {


            /*********** DbContext Configuration **************/
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            
            /********************** IoC ************************/
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICowService, CowManager>();
            services.AddScoped<IBullService, BullManager>();
            services.AddScoped<IMilkRecordService, MilkRecordManager>();
            services.AddScoped<ILactationService, LactationManager>();
            services.AddScoped<ISeminationService, SeminationManager>();
            services.AddScoped<ICalvingService, CalvingManager>();
            services.AddScoped<IEmployeeService, EmployeeManager>();


            /*************** AutoMapper Configuration *************/
            services.AddAutoMapper(typeof(CowProfile));


            return services;
        }
    }

}
