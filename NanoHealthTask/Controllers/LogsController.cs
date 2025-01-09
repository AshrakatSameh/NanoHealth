using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NanoHealthTask.Interfaces;
using NanoHealthTask.Models;

namespace NanoHealthTask.Controllers
{
    [Route("api/v1/logs")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogsController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        public async Task<IActionResult> StoreLog([FromBody] LogEntryRequest logRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _logService.StoreLogAsync(logRequest);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> RetrieveLogs([FromQuery] LogFilter filter)
        {
            //var logs = await _logService.RetrieveLogsAsync(filter);
            //return Ok(logs);
            if (filter == null)
            {
                filter = new LogFilter(); // Optional: Set default values for the filter
            }

            var logs = await _logService.RetrieveLogsAsync(filter);
            return Ok(logs);
        }
    }
}
