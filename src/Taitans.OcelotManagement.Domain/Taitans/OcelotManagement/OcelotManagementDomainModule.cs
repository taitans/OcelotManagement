using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Taitans.OcelotManagement
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(OcelotManagementDomainSharedModule)
        )]
    public class OcelotManagementDomainModule : AbpModule
    {

    }
}
