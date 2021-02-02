using Taitans.OcelotManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Taitans.OcelotManagement
{
    [DependsOn(
        typeof(AbpOcelotManagementEntityFrameworkCoreTestModule),
        typeof(OcelotManagementTestBaseModule)
        )]
    public class OcelotManagementDomainTestModule : AbpModule
    {

    }
}
