using CsvHelper.Configuration;
using CsvHelper;
using Geocode.Interfaces;
using System.Globalization;
using Geocode.Models;

namespace Geocode.Services
{
    public class GeoDataImport : IGeoDataImport
    {
        public Task<bool> ImportData()
        {
            //read data from file in /data/uszips.csv
            using (var reader = new StreamReader("Data\\uszips.csv"))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Context.RegisterClassMap<GeoDataMap>();
                var records = csv.GetRecords<GeoData>();

                foreach (var record in records)
                {
                    // Process each record
                }
            }

            return Task.FromResult(true);
        }
    }
}
