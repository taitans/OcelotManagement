using Taitans.OcelotManagement.Localization;
using Volo.Abp.Application.Services;

namespace Taitans.OcelotManagement
{
    public abstract class OcelotManagementAppServiceBase : ApplicationService
    {
        protected OcelotManagementAppServiceBase()
        {
            LocalizationResource = typeof(OcelotManagementResource);
            ObjectMapperContext = typeof(AbpOcelotManagementApplicationModule);
        }
    }
}
