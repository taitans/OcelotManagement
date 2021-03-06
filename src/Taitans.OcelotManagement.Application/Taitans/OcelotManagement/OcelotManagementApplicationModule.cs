﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Taitans.OcelotManagement
{
    [DependsOn(
        typeof(OcelotManagementDomainModule),
        typeof(OcelotManagementApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class OcelotManagementApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<OcelotManagementApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<OcelotManagementApplicationAutoMapperProfile>();
            });
        }
    }
}
