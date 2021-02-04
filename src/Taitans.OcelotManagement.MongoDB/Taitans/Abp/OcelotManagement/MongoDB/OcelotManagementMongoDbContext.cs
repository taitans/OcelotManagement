using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Taitans.OcelotManagement.MongoDB
{
    [ConnectionStringName(OcelotManagementDbProperties.ConnectionStringName)]
    public class OcelotManagementMongoDbContext : AbpMongoDbContext, IOcelotManagementMongoDbContext
    {
        public IMongoCollection<Ocelot> Ocelots => Collection<Ocelot>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureOcelotManagement();
        }
    }
}