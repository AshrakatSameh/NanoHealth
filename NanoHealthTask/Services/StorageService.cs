using Microsoft.EntityFrameworkCore;
using NanoHealthTask.Context;
using NanoHealthTask.Interfaces;
using NanoHealthTask.Models;

namespace NanoHealthTask.Services
{
    public class StorageService : IStorageService
    {
        private readonly AppDbContext _context;

        public StorageService(AppDbContext context)
        {
            _context = context;
        }

        // Store the log entry in the database
        public async Task<string> StoreLogAsync(LogEntryRequest logRequest)
        {
            var logEntry = new LogEntryRequest
            {
                Service = logRequest.Service,
                Level = logRequest.Level,
                Message = logRequest.Message,
                Timestamp = logRequest.Timestamp
            };

            _context.LogEntries.Add(logEntry);
            await _context.SaveChangesAsync();

            return "Log stored successfully in the database.";
        }

        // Retrieve logs based on the provided filter
        public async Task<IEnumerable<LogEntryResponse>> RetrieveLogsAsync(LogFilter filter)
        {
            var query = _context.LogEntries.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Service))
                query = query.Where(log => log.Service == filter.Service);

            if (!string.IsNullOrEmpty(filter.Level))
                query = query.Where(log => log.Level == filter.Level);

            if (filter.StartTime.HasValue)
                query = query.Where(log => log.Timestamp >= filter.StartTime.Value);

            if (filter.EndTime.HasValue)
                query = query.Where(log => log.Timestamp <= filter.EndTime.Value);

            var logs = await query.ToListAsync();
            return logs.Select(log => new LogEntryResponse
            {
                Service = log.Service,
                Level = log.Level,
                Message = log.Message,
                Timestamp = log.Timestamp
            });
        }
    }
}
