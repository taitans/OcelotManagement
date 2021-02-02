using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Taitans.OcelotManagement.EntityFrameworkCore
{
    public class OcelotManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public OcelotManagementModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}