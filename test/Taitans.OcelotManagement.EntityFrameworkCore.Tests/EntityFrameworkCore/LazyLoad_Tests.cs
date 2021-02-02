using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;

namespace Taitans.OcelotManagement.EntityFrameworkCore
{
    public class LazyLoad_Tests : LazyLoad_Tests<AbpOcelotManagementEntityFrameworkCoreTestModule>
    {
        protected override void BeforeAddApplication(IServiceCollection services)
        {
            services.Configure<AbpDbContextOptions>(options =>
            {
                options.PreConfigure<OcelotManagementDbContext>(context =>
                {
                    context.DbContextOptions.UseLazyLoadingProxies();
                });
            });
        }
    }
}
