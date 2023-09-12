using Geocode.Models;
using Geocode.Interfaces;
using Geocode.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Geocode.Services
{
    public class Geocode : IGeocode
    {
        readonly IServiceScopeFactory<GeoDataContext> _context;
        private ILogger<Geocode> _log;
        public Geocode(IServiceScopeFactory<GeoDataContext> context, ILogger<Geocode> log)
        {
            _context = context;
            _log = log;
        }
        public async Task<string> GetStateByZip(int zipcode)
        {
            using var scope = _context.CreateScope();
            var db = scope.GetRequiredService();
            _log.LogInformation("Attempting to get required service at GetStateByZip");

            var state = await db.GeoData.Where(x => x.Zip == zipcode).Select(x => x.StateName).FirstOrDefaultAsync();

            return state;
        }

        public async Task<GeocodeLookupResponse> KeywordLookup(string Keyword)
        {
            using var scope = _context.CreateScope();
            _log.LogInformation("Attempting to get required service at KeywordLookup");
            var db = scope.GetRequiredService();

            var data = await db.GeoData
                .Where(x => x.City == Keyword)
                .Where(x => x.StateName == Keyword)
                .Where(x => x.CountyName == Keyword)
                .Where(x => x.Zip.ToString() == Keyword)
                .ToListAsync();
            return new GeocodeLookupResponse()
            {
                Data = data,
                Success = true
            };
        }

        public async Task<GeocodeLookupResponse> ZipcodeLookup(int zipcode)
        {
            using var scope = _context.CreateScope();
            _log.LogInformation("Attempting to get required service at ZipcodeLookup");
            var db = scope.GetRequiredService();

            var data = await db.GeoData.Where(x => x.Zip == zipcode).ToListAsync();
            return new GeocodeLookupResponse()
            {
               Data = data,
               Success = true
            };
        }
    }
}
