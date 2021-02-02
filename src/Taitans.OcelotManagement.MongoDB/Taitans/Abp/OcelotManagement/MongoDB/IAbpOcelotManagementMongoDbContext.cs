using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Taitans.OcelotManagement.MongoDB
{
    [ConnectionStringName(OcelotManagementDbProperties.ConnectionStringName)]
    public interface IAbpOcelotManagementMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<Ocelot> Ocelots { get; }
    }
}
