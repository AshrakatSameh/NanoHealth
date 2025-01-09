using NanoHealthTask.Models;

namespace NanoHealthTask.Interfaces
{
    public interface IStorageService
    {
        Task<string> StoreLogAsync(LogEntryRequest logRequest);
        Task<IEnumerable<LogEntryResponse>> RetrieveLogsAsync(LogFilter filter);
    }
}
