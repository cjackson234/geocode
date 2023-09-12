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
        readonly ILogger<ImportController> _log;

        public ImportController(IGeoDataImport geoDataImport, ILogger<ImportController> log)
        {
            _geoDataImport = geoDataImport;
            _log = log;
        }

        [HttpPost]
        public async Task<IActionResult> ImportData()
        {
            _log.LogInformation("Attempting ImportData");
            var result = await _geoDataImport.ImportData();
            return Ok(result);
        }
    }
}
