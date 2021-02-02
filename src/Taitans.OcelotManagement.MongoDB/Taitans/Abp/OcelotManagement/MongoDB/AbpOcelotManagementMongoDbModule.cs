using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Taitans.OcelotManagement.MongoDB
{
    [DependsOn(
        typeof(OcelotManagementDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class AbpOcelotManagementMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<AbpOcelotManagementMongoDbContext>(options =>
            {
                options.AddDefaultRepositories<IAbpOcelotManagementMongoDbContext>();

                options.AddRepository<Ocelot, MongoOcelotRepository>();
            });
        }
    }
}
