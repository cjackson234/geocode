using Geocode.Models;

namespace Geocode.Helpers
{
    public static class Transformers
    {
        public static Models.GeoData Transform(this CsvGeoData data)
        {
            return new Models.GeoData()
            {
                Id = Guid.NewGuid(),
                Zip = int.Parse(data.Zip),
                Lat = data.Lat,
                Lng = data.Lng,
                City = data.City,
                StateId = data.StateId,
                StateName = data.StateName,
                Zcta = data.Zcta,
                ParentZcta = data.ParentZcta,
                Population = data.Population,
                Density = data.Density,
                CountyFips = data.CountyFips,
                CountyName = data.CountyName,
                CountyWeights = data.CountyWeights,
                CountyNames = data.CountyNamesAll.Select(x => new CountyNames() { Id = Guid.NewGuid(), CountyName = x }).ToList(),
                CountyFipsData = data.CountyFipsAll.Select(x => new CountyFipsData() { Id = Guid.NewGuid(), CountyFips = x }).ToList(),
                Imprecise = data.Imprecise,
                Military = data.Military,
                Timezone = data.Timezone
            };
        }
    }
}
