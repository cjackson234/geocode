using Geocode.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geocode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private readonly IGeoDataImport _geoDataImport;

        public ImportController(IGeoDataImport geoDataImport)
        {
            _geoDataImport = geoDataImport;
        }

        [HttpPost]
        public async Task<IActionResult> ImportData()
        {
            var result = await _geoDataImport.ImportData();
            return Ok(result);
        }
    }
}
