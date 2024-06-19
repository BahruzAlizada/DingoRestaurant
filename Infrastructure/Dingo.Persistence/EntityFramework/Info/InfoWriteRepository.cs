using Dingo.Application.Abstracts;
using Dingo.Domain.Entities;
using Dingo.Persistence.Repositories;

namespace Dingo.Persistence.EntityFramework
{
    public class InfoWriteRepository : WriteRepository<Info>,IInfoWriteRepository
    {
    }
}
