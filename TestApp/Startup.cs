using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TestApp.Core;
using TestApp.Core.Interfaces;
using TestApp.DataStore;
using TestApp.Repositories;
namespace TestApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterType<PlayerRepository>().As<IRepository<Player>>();
            builder.RegisterType<ClubRepository>().As<IRepository<Club>>();
            builder.RegisterType<DataStoreProvider>().As<IDataStoreProvider<Club>>().As<IDataStoreProvider<Player>>();
            AppContainer = builder.Build();

            return new AutofacServiceProvider(AppContainer);
        }
        
        public IContainer AppContainer { get; private set; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();

        }
    }
}
