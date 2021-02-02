using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Taitans.OcelotManagement.EntityFrameworkCore
{
    [DependsOn(
        typeof(OcelotManagementDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class OcelotManagementEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<OcelotManagementDbContext>(options =>
            {
                options.AddRepository<Ocelot, EfCoreOcelotRepository>();
            });
        }
    }
}