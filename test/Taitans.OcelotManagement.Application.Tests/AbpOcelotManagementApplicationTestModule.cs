using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Taitans.OcelotManagement
{
    [DependsOn(
        typeof(AbpOcelotManagementApplicationModule),
        typeof(OcelotManagementDomainTestModule)
        )]
    public class AbpOcelotManagementApplicationTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}
