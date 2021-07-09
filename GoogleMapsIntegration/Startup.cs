using System;
using System.Collections.Generic;
using Abstraction.Common;
using Abstraction.Location;
using Api.AutoMapperProfiles;
using AutoMapper;
using Data;
using Data.Entities.Location;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Model.Location;
using Service.Location;
using Service.Location.Creators;
using Service.Location.Handlers;
using Service.Location.Readers;
using Service.Location.Updaters;

namespace GoogleMapsIntegration
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(connection));


            services.Configure<GoogleAPIConfig>(Configuration.GetSection(nameof(GoogleAPIConfig)));
            services.AddScoped<BaseLocationPartHandler>();
            services.AddScoped<IGeolocationService, GoogleAPIService>();

            services.AddScoped<ILocationHandlerFactory, LocationHandlerFactory>();
            services.AddScoped<ILocationFactory, LocationFactory>();

            services.AddScoped<ILocationHandler<LocationModel, Guid?>, ClientLocationHandler>();
            services.AddScoped<ILocationHandler<LocationModel, Guid?>, EventLocationHandler>();

            #region IModelGenerator

            services.AddScoped<IModelGenerator<IDictionary<string, string[]>, IDictionary<string, string>>, ClientLocationModelGenerator>();
            services.AddScoped<IModelGenerator<IDictionary<string, string[]>, IDictionary<string, string>>, EventLocationModelGenerator>();

            #endregion

            #region IDataReader

            services.AddScoped<IDataReader<string, Guid?>, LocalityReader>();
			services.AddScoped<IDataReader<string, Guid?>, SublocalityReader>();
			services.AddScoped<IDataReader<string, Guid?>, RouteReader>();
			services.AddScoped<IDataReader<string, Guid?>, PostalCodeReader>();
			services.AddScoped<IDataReader<string, Guid?>, AdministrativeAreaLevel1Reader>();
			services.AddScoped<IDataReader<string, Guid?>, AdministrativeAreaLevel2Reader>();
			services.AddScoped<IDataReader<string, Guid?>, AdministrativeAreaLevel3Reader>();
			services.AddScoped<IDataReader<string, Guid?>, AdministrativeAreaLevel4Reader>();
			services.AddScoped<IDataReader<string, Guid?>, AdministrativeAreaLevel5Reader>();
			services.AddScoped<IDataReader<string, Guid?>, CountryReader>();
			services.AddScoped<IDataReader<Guid?, ClientLocation>, ClientLocationReader>();
			services.AddScoped<IDataReader<Guid?, EventLocation>, EventLocationReader>();

			#endregion

			#region IDataCreator

			services.AddScoped<IDataCreator<LocationPartCreatorModel, Guid>, LocalityCreator>();
			services.AddScoped<IDataCreator<LocationPartCreatorModel, Guid>, SublocalityCreator>();
			services.AddScoped<IDataCreator<LocationPartCreatorModel, Guid>, RouteCreator>();
			services.AddScoped<IDataCreator<LocationPartCreatorModel, Guid>, PostalCodeCreator>();
			services.AddScoped<IDataCreator<LocationPartCreatorModel, Guid>, AdministrativeAreaLevel1Creator>();
			services.AddScoped<IDataCreator<LocationPartCreatorModel, Guid>, AdministrativeAreaLevel2Creator>();
			services.AddScoped<IDataCreator<LocationPartCreatorModel, Guid>, AdministrativeAreaLevel3Creator>();
			services.AddScoped<IDataCreator<LocationPartCreatorModel, Guid>, AdministrativeAreaLevel4Creator>();
			services.AddScoped<IDataCreator<LocationPartCreatorModel, Guid>, AdministrativeAreaLevel5Creator>();
			services.AddScoped<IDataCreator<LocationPartCreatorModel, Guid>, CountryCreator>();
			services.AddScoped<IDataCreator<BaseLocationCreatorModel, Guid>, ClientLocationCreator>();
			services.AddScoped<IDataCreator<BaseLocationCreatorModel, Guid>, EventLocationCreator>();

			#endregion

			#region IDataUpdater

			services.AddScoped<IDataUpdater<(BaseLocationCreatorModel, ClientLocation), Guid?>, ClientLocationUpdater>();
			services.AddScoped<IDataUpdater<(BaseLocationCreatorModel, EventLocation), Guid?>, EventLocationUpdater>();

            #endregion

            services.AddSingleton(provider => new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ClientLocationProfile());
                mc.AddProfile(new EventLocationProfile());
            }).CreateMapper());
            services.AddCors();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
