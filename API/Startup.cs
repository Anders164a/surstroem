using API.Service.Interfaces;
using API.Service.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using surstroem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            var connectionString = Configuration.GetConnectionString("surstroemDB");
            services.AddDbContext<surstroemContext>(cnn => cnn.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 11))).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            //.AddScoped<ICategoryRepository, CategoryRepository>()
            services.AddScoped<ICountryRepository, CountryRepository>();
            //.AddScoped<IDeliveryStateRepository, DeliveryStateRepository>()
            //.AddScoped<IDeliveryTypeRepository, DeliveryTypeRepository>()
            //.AddScoped<IEmployeeRepository, EmployeeRepository>()
            //.AddScoped<IEmployeeHasShiftRepository, EmployeeHasShiftRepository>()
            //.AddScoped<IOrderRepository, OrderRepository>()
            //.AddScoped<IOrderProductRepository, OrderProductRepository>()
            services.AddScoped<IPostalCodeRepository, PostalCodeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            //.AddScoped<IProductCategoryRepository, ProductCategoryRepository>()
            //.AddScoped<IReviewRepository, ReviewRepository>()
            //.AddScoped<IReviewOpinionRepository, ReviewOpinionRepository>()
            //.AddScoped<IShiftRepository, ShiftRepository>()
            //.AddScoped<IStockRepository, StockRepository>()
            services.AddScoped<IUserRepository, UserRepository>();
            //.AddScoped<IWarehouseRepository, WarehouseRepository>()
            //.AddScoped<IWarehouseTypeRepository, WarehouseTypeRepository>()
            services.AddScoped<IWarrantyPeriodRepository, WarrantyPeriodRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
