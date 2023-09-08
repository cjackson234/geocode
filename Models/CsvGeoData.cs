using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.Configuration;
using Geocode.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Geocode.Models
{
    public class CsvGeoData
    {
        [Key]
        public Guid Id { get; set; }
        public string Zip { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string City { get; set; }
        public string StateId { get; set; }
        public string StateName { get; set; }
        public string Zcta { get; set; }
        public string ParentZcta { get; set; }
        public int? Population { get; set; }
        public double? Density { get; set; }
        public string CountyFips { get; set; }
        public string CountyName { get; set; }
        public string CountyWeights { get; set; }
        public List<string> CountyNamesAll { get; set; }
        public List<string> CountyFipsAll { get; set; }
        public bool Imprecise { get; set; }
        public bool Military { get; set; }
        public string Timezone { get; set; }
    }

    public sealed class GeoDataMap : ClassMap<CsvGeoData>
    {
        public GeoDataMap()
        {
            Map(m => m.Zip).Name("zip");
            Map(m => m.Lat).Name("lat");
            Map(m => m.Lng).Name("lng");
            Map(m => m.City).Name("city");
            Map(m => m.StateId).Name("state_id");
            Map(m => m.StateName).Name("state_name");
            Map(m => m.Zcta).Name("zcta");
            Map(m => m.ParentZcta).Name("parent_zcta");
            Map(m => m.Population).Name("population");
            Map(m => m.Density).Name("density");
            Map(m => m.CountyFips).Name("county_fips");
            Map(m => m.CountyName).Name("county_name");
            Map(m => m.CountyWeights).Name("county_weights");
            Map(m => m.CountyNamesAll).Name("county_names_all").TypeConverter<ListTypeConverter<string>>();
            Map(m => m.CountyFipsAll).Name("county_fips_all").TypeConverter<ListTypeConverter<string>>();
            Map(m => m.Imprecise).Name("imprecise");
            Map(m => m.Military).Name("military");
            Map(m => m.Timezone).Name("timezone");
        }
    }
}
