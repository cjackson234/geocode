﻿using Geocode.Models;
using Geocode.Interfaces;
using Geocode.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Geocode.Services
{
    public class GeocodeService : IGeocode
    {
        readonly IServiceScopeFactory<GeoDataContext> _context;
        public GeocodeService(IServiceScopeFactory<GeoDataContext> context)
        {
            _context = context;
        }
        public async Task<string> GetStateByZip(int zipcode)
        {
            using var scope = _context.CreateScope();
            var db = scope.GetRequiredService();

            var state = await db.GeoData.Where(x => x.Zip == zipcode).Select(x => x.StateName).FirstOrDefaultAsync();

            return state;
        }

        public async Task<GeocodeLookupResponse> KeywordLookup(string Keyword)
        {
            using var scope = _context.CreateScope();
            var db = scope.GetRequiredService();

            var data = await db.GeoData
               .Where(x => x.City.Contains(Keyword) ||
                 x.StateName == Keyword ||
                 x.CountyName == Keyword ||
                 x.Zip.ToString() == Keyword)
               .Take(10)
               .ToListAsync();
            return new GeocodeLookupResponse()
            {
                Data = data,
                Success = true
            };
        }

        public async Task<GeocodeLookupResponse> LatLongLookup(double lat, double lng)
        {
            using var scope = _context.CreateScope();
            var db = scope.GetRequiredService();
            
            //consider redis for this
            var cites = await db.GeoData
               .Select(x => new { Id = x.Id, Lat = x.Lat, Lng = x.Lng })
               .ToListAsync();

            var found = cites.Where(x => ArePointsNear(lat, lng, x.Lat, x.Lng, 4)).Take(10);

            var data = await db.GeoData
               .Where(x => found.Select(y => y.Id).Contains(x.Id))
               .ToListAsync();
            return new GeocodeLookupResponse()
            {
                Data = data,
                Success = true
            };
        }

        private bool ArePointsNear(double lat, double lng, double db_lat, double db_lng, int miles)
        {
            var km = miles * 1.609344;
            var ky = 40000 / 360;
            var kx = Math.Cos(Math.PI * lat / 180.0) * ky;
            var dx = Math.Abs(lng - db_lng) * kx;
            var dy = Math.Abs(lat - db_lat) * ky;
            return Math.Sqrt(dx * dx + dy * dy) <= km;
        }

        public async Task<GeocodeLookupResponse> ZipcodeLookup(int zipcode)
        {
            using var scope = _context.CreateScope();
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
