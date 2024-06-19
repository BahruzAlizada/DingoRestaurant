using Dingo.Application.Repositories;
using Dingo.Domain.Entities;

namespace Dingo.Application.Abstracts
{
    public interface IContactWriteRepository : IWriteRepository<Contact>
    {
    }
}
