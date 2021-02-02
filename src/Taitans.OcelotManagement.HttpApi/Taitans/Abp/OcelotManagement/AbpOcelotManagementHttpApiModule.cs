using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Taitans.OcelotManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Taitans.OcelotManagement
{
    [DependsOn(
        typeof(OcelotManagementApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class AbpOcelotManagementHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpOcelotManagementHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<OcelotManagementResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
