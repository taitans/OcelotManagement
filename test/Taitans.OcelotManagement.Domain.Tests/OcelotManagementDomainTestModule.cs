using Taitans.OcelotManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Taitans.OcelotManagement
{
    [DependsOn(
        typeof(OcelotManagementEntityFrameworkCoreTestModule),
        typeof(OcelotManagementTestBaseModule)
        )]
    public class OcelotManagementDomainTestModule : AbpModule
    {

    }
}
