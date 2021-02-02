using Taitans.OcelotManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Taitans.OcelotManagement
{
    public abstract class OcelotController : AbpController
    {
        protected OcelotController()
        {
            LocalizationResource = typeof(OcelotManagementResource);
        }
    }
}
