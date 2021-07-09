using Data.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using System;

namespace Data
{
    public class BaseDbContext : DbContext
    {
        #region Common models

        public DbSet<Client> Clients {get;set;}

        public DbSet<Event> Events {get;set;}

        #endregion

        #region GoogleAPI models

        #region BaseModels

        public DbSet<AdministrativeAreaLevel1> AdministrativeAreasLevel1 { get; set; }
        public DbSet<AdministrativeAreaLevel2> AdministrativeAreasLevel2 { get; set; }
        public DbSet<AdministrativeAreaLevel3> AdministrativeAreasLevel3 { get; set; }
        public DbSet<AdministrativeAreaLevel4> AdministrativeAreasLevel4 { get; set; }
        public DbSet<AdministrativeAreaLevel5> AdministrativeAreasLevel5 { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Sublocality> Sublocalities { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }

        #endregion

        public DbSet<ClientLocation> ClientLocations { get; set; }

        public DbSet<EventLocation> EventLocations { get; set; }

        #endregion

        public BaseDbContext(DbContextOptions<BaseDbContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(new Client { Id=Guid.Parse("edcd441e-83e7-4653-b0e9-111111111111"), Name="Alexander" });
            modelBuilder.Entity<Event>().HasData(new Client { Id = Guid.Parse("edcd441e-83e7-4653-b0e9-222222222222"), Name = "Birthday" });
        }

    }
}
