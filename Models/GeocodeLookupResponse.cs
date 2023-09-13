namespace Geocode.Models
{
    public class GeocodeLookupResponse
    {
        public List<GeoData> Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}