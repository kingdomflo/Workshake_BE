using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WorkShake.Models;
using AutoMapper;
using WorkShake.Services;
using WorkShake.Repositories;
using WorkShake.Utils;
using System.Net.Mime;

namespace WorkShake
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
      services.AddDbContext<WorkShakeContext>(opt => opt.UseInMemoryDatabase("WorkShakeDb"));
      services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
      );
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

      services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));

      services.AddScoped<IChainStoreRepository, ChainStoreRepository>();
      services.AddScoped<IChainStoreService, ChainStoreService>();

      services.AddScoped<IStoreRepository, StoreRepository>();
      services.AddScoped<IStoreService, StoreService>();

      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IUserService, UserService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WorkShakeContext context)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseExceptionHandler("/error");

      context.EnsureSeedDataForContext();

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
