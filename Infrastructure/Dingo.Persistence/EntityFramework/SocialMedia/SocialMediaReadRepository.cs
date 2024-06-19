using Dingo.Application.Abstracts;
using Dingo.Domain.Entities;
using Dingo.Persistence.Concrete;
using Dingo.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Dingo.Persistence.EntityFramework
{
    public class SocialMediaReadRepository : ReadRepository<SocialMedia>, ISocialMediaReadRepository
    {
        private readonly IMemoryCache memoryCache;
        public SocialMediaReadRepository(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public async Task<List<SocialMedia>> GetCachingActiveSocialMediasAsync()
        {
            using var context = new Context();

            List<SocialMedia> socialMedias;
            const string cachedSocialMediaKey = "SocialMedias";
            
            if(!memoryCache.TryGetValue(cachedSocialMediaKey, out socialMedias))
            {
                socialMedias = await context.socialMedias.Where(x => x.Status).ToListAsync();

                memoryCache.Set(cachedSocialMediaKey, socialMedias,new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(3),
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(9),
                    Priority = CacheItemPriority.Normal
                });
            }
            return socialMedias;
        }
    }
}
