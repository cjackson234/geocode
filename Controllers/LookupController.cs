using Geocode.Interfaces;
using Geocode.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Geocode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly IGeocode _geocode;

        LookupController(IGeocode geocode)
        {
            _geocode = geocode;
        }

        [HttpGet]
        public async Task<GeocodeLookupResponse> ZipcodeLookup(int zipcode)
        {
            return await _geocode.ZipcodeLookup(zipcode);
        }

        [HttpGet]
        public async Task<GeocodeLookupResponse> KeywordLookup(string keyword)
        {
            return await _geocode.KeywordLookup(keyword);
        }
    }
}
