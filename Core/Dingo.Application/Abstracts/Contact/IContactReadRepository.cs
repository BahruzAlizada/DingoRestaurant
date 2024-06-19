﻿using Dingo.Application.Repositories;
using Dingo.Domain.Entities;

namespace Dingo.Application.Abstracts
{
    public interface IContactReadRepository : IReadRepository<Contact>
    {
    }
}
