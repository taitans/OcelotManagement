using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Taitans.OcelotManagement
{
    [DependsOn(
        typeof(OcelotManagementApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class OcelotHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Ocelot";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(OcelotManagementApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
