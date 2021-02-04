using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Taitans.OcelotManagement.MongoDB
{
    [DependsOn(
        typeof(OcelotManagementDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class OcelotManagementMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<OcelotManagementMongoDbContext>(options =>
            {
                options.AddDefaultRepositories<IOcelotManagementMongoDbContext>();

                options.AddRepository<Ocelot, MongoOcelotRepository>();
            });
        }
    }
}
