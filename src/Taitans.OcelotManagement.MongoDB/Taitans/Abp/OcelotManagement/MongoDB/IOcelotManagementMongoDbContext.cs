using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Taitans.OcelotManagement.MongoDB
{
    [ConnectionStringName(OcelotManagementDbProperties.ConnectionStringName)]
    public interface IOcelotManagementMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<Ocelot> Ocelots { get; }
    }
}
