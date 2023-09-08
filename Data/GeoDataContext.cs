namespace Geocode.Data
{
    using Geocode.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public class GeoDataContext : DbContext
    {
        private readonly IConfiguration _config;

        public GeoDataContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<GeoData> GeoData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetValue<string>("ConnectionStrings:Database"));
        }
    }
}
