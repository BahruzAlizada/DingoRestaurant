using Dingo.Application.Abstracts;
using Dingo.Domain.Entities;
using Dingo.Persistence.Concrete;
using Dingo.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Dingo.Persistence.EntityFramework
{
    public class InfoReadRepository : ReadRepository<Info>, IInfoReadRepository
    {
        private readonly IMemoryCache memoryCache;
        public InfoReadRepository(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public async Task<Info> GetCachingInfoAsync()
        {
            using var context = new Context();

            Info info;
            const string cachedInfoKey = "Info";

            if(!memoryCache.TryGetValue(cachedInfoKey, out info))
            {
                info = await context.Infos.FirstOrDefaultAsync();

                memoryCache.Set(cachedInfoKey, info, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(3),
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(9),
                    Priority = CacheItemPriority.Normal
                });
            }
            return info;
        }
    }
}
