using NanoHealthTask.Models;

namespace NanoHealthTask.Interfaces
{
    public interface ILogService
    {
        Task<string> StoreLogAsync(LogEntryRequest logRequest);
        Task<IEnumerable<LogEntryResponse>> RetrieveLogsAsync(LogFilter filter);
    }
}
