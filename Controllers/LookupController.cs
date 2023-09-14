using Geocode.Interfaces;
using Geocode.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace Geocode.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly IGeocode _geocode;

        public LookupController(IGeocode geocode)
        {
            _geocode = geocode;
        }

        /// <summary>
        /// Returns all data matching provided zipcode
        /// </summary>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        [HttpGet("Zipcode")]
        public async Task<GeocodeLookupResponse> ZipcodeLookup(int zipcode)
        {
            return await _geocode.ZipcodeLookup(zipcode);
        }

        /// <summary>
        /// Returns all data matching provided keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet("Keyword")]
        public async Task<GeocodeLookupResponse> KeywordLookup(string keyword)
        {
            return await _geocode.KeywordLookup(keyword);
        }

        /// <summary>
        /// Returns all data matching provided keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet("LatLong")]
        public async Task<GeocodeLookupResponse> LatLongLookup(double lat, double lng)
        {
            return await _geocode.LatLongLookup(lat, lng);
        }
    }
}
