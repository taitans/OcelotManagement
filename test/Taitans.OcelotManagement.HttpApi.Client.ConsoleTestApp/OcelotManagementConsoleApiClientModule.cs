using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Taitans.OcelotManagement
{
    [DependsOn(
        typeof(OcelotManagementHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class OcelotManagementConsoleApiClientModule : AbpModule
    {
        
    }
}
