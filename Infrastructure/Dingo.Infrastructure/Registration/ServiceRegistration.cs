using Dingo.Infrastructure.Abstract;
using Dingo.Infrastructure.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Dingo.Infrastructure.Registration
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<IPhotoService, PhotoService>();
        }
    }
}
