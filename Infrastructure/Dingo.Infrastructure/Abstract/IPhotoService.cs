using Microsoft.AspNetCore.Http;

namespace Dingo.Infrastructure.Abstract
{
    public interface IPhotoService
    {
        Task<(bool,string)> PhotoChechkValidatorAsync(IFormFile photo,bool IsAllowNull, bool IsOlder256Kb);
        Task<string> SavePhotoAsync(IFormFile Photo, string folder);
        void DeletePhoto(string path);
    }
}
