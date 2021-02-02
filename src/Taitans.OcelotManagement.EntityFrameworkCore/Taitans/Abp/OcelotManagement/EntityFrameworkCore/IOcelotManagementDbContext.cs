using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Taitans.OcelotManagement.EntityFrameworkCore
{
    [ConnectionStringName(OcelotManagementDbProperties.ConnectionStringName)]
    public interface IOcelotManagementDbContext : IEfCoreDbContext
    {
        DbSet<Ocelot> GlobalConfigurations { get; set; }
    }
}