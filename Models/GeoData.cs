namespace Geocode.Models
{
    public class GeoData
    {
        public string Zip { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string City { get; set; }
        public string StateId { get; set; }
        public string StateName { get; set; }
        public string Zcta { get; set; }
        public string ParentZcta { get; set; }
        public int Population { get; set; }
        public double Density { get; set; }
        public string CountyFips { get; set; }
        public string CountyName { get; set; }
        public string CountyWeights { get; set; }
        public List<string> CountyNamesAll { get; set; }
        public List<string> CountyFipsAll { get; set; }
        public bool Imprecise { get; set; }
        public bool Military { get; set; }
        public string Timezone { get; set; }
    }
}
