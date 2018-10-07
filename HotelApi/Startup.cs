using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelApi.Filters;
using HotelApi.Infrastructure;
using HotelApi.Models;
using HotelApi.Services;
using LandonApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSwag.AspNetCore;

namespace HotelApi
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

            services.Configure<HotelInfo>(Configuration.GetSection("Info"));
            services.Configure<HotelOptions>(Configuration);
            services.AddScoped<IRoomService, DefaultRoomService>();
            services.AddScoped<IOpeningService, DefaultOpeningService>();
            services.AddScoped<IBookingService, DefaultBookingService>();
            services.AddScoped<IDateLogicService, DefaultDateLogicService>();

            services.Configure<PagingOptions>(Configuration.GetSection("DefaultPagingOptions"));


            //Use in-memory database for quick dev and testing
            //swap with real databse for  production    

            services.AddDbContext<HotelApiDbContext>(options => options.UseInMemoryDatabase("LocalHotel"));


            services.AddMvc(options =>
                {
                    options.Filters.Add<JsonExceptionFilter>();
                    options.Filters.Add<RequireHttpsOrCloseAttribute>();

                    options.Filters.Add<LinkRewritingFilter>();


                }
                
                ).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new MediaTypeApiVersionReader();

                options.AssumeDefaultVersionWhenUnspecified = true;

                options.ReportApiVersions = true;
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            });

            services.AddAutoMapper(
                options => options.AddProfile<MappingProfile>());


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errorResponse = new ApiError(context.ModelState);
                    return new BadRequestObjectResult(errorResponse);
                };
            });


                services.AddCors(options =>
                {
                    options.AddPolicy("AllowApp",
                    //policy=> policy.WithOrigins("https://example.com")  //create a white list for prodution environment.
                    policy => policy.AllowAnyOrigin()); // allowing all for dev 


                    

                });


         

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUi3WithApiExplorer(options =>
                    {
                        options.GeneratorSettings.DefaultPropertyNameHandling =
                        NJsonSchema.PropertyNameHandling.CamelCase;
                    }
                );
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("AllowMyApp");
          
            app.UseMvc();
        }
    }
}
