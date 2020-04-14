using System;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ICacheService
    {
        void Set(object key);

        void Remove(object key);

        bool TryGet(object key, out object value);

        TItem GetOrCreate<TItem>(object key, Func<ICacheEntry, TItem> factory);

        Task<TItem> GetOrCreateAsync<TItem>(object key, Func<ICacheEntry, TItem> factory);

        TItem Set<TItem>(object key, TItem value, DateTimeOffset absoluteExpiration);

        TItem Set<TItem>(object key, TItem value, TimeSpan absoluteExpirationRelativeToNow);
    }

    public interface ICacheEntry
    {
        DateTimeOffset? AbsoluteExpiration { get; set; }
        TimeSpan? AbsoluteExpirationRelativeToNow { get; set; }
        TimeSpan? SlidingExpiration { get; set; }
        object Key { get; }
        object Value { get; }
    }

    public class CacheEntryOptions
    {
        public CacheEntryOptions()
        {

        }

        public DateTimeOffset? AbsoluteExpiration { get; set; }
        public TimeSpan? AbsoluteExpirationRelativeToNow { get; set; }
        public TimeSpan? SlidingExpiration { get; set; }
    }


}
