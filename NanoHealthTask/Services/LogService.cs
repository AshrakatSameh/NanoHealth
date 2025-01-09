using NanoHealthTask.Interfaces;
using NanoHealthTask.Models;

namespace NanoHealthTask.Services
{
    public class LogService : ILogService
    {
        private readonly IStorageService _storageService;

        public LogService(IStorageService storageService)
        {
            _storageService = storageService;
        }
        public async Task<IEnumerable<LogEntryResponse>> RetrieveLogsAsync(LogFilter filter)
        {
            return await _storageService.RetrieveLogsAsync(filter);
        }

        public async Task<string> StoreLogAsync(LogEntryRequest logRequest)
        {
            return await _storageService.StoreLogAsync(logRequest);

        }
    }
}
