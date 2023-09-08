using CsvHelper.Configuration;
using CsvHelper;
using Geocode.Interfaces;
using System.Globalization;
using Geocode.Models;
using Microsoft.EntityFrameworkCore;
using Geocode.Data;
using Geocode.Helpers;

namespace Geocode.Services
{
    public class GeoDataImport : IGeoDataImport
    {
        readonly IServiceScopeFactory<GeoDataContext> _context;
        public GeoDataImport(IServiceScopeFactory<GeoDataContext> context)
        {
            _context = context;
        }
        public Task<bool> ImportData()
        {
            //read data from file in /data/uszips.csv
            using (var reader = new StreamReader("Data\\uszips.csv"))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Context.RegisterClassMap<GeoDataMap>();
                var records = csv.GetRecords<CsvGeoData>();

                using var scope = _context.CreateScope();
                var db = scope.GetRequiredService();

                foreach (var record in records)
                {
                    var d = record.Transform();
                    db.GeoData.Add(d);
                }

                db.SaveChanges();
            }

            return Task.FromResult(true);
        }
    }
}
