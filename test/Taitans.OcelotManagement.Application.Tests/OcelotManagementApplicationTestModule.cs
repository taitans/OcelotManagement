using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Taitans.OcelotManagement
{
    [DependsOn(
        typeof(OcelotManagementApplicationModule),
        typeof(OcelotManagementDomainTestModule)
        )]
    public class OcelotManagementApplicationTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}
