using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Taitans.OcelotManagement.EntityFrameworkCore
{
    public class EfCoreOcelotRepository : EfCoreRepository<IOcelotManagementDbContext, Ocelot, Guid>, IOcelotRepository
    {
        public EfCoreOcelotRepository(IDbContextProvider<IOcelotManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async override Task<IQueryable<Ocelot>> WithDetailsAsync()
        {
            return (await base.WithDetailsAsync()).IncludeDetails(true);
        }

        public async Task<Ocelot> FindByNameAsync(string name, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            var query = from global in (await GetDbSetAsync()).IncludeDetails(includeDetails)
                        where global.Name == name
                        select global;

            return await query.FirstOrDefaultAsync(GetCancellationToken(cancellationToken)).ConfigureAwait(false);
        }

        public async Task<List<OcelotRoute>> GetRoutesAsync(Guid id)
        {
            return await (await GetDbContextAsync()).Set<OcelotRoute>()
                .IncludeDetails(true)
                .Where(c => c.GlobalConfigurationId == id).OrderBy(c => c.Sort)
                .ToListAsync();
        }
    }
}
