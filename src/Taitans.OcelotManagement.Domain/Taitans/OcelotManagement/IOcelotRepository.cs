﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Taitans.OcelotManagement
{
    public interface IOcelotRepository : IRepository<Ocelot, Guid>
    {
        Task<List<OcelotRoute>> GetRoutesAsync(Guid id);

        Task<Ocelot> FindByNameAsync(
            string name,
            bool includeDetails = true,
            CancellationToken cancellationToken = default);
    }
}
