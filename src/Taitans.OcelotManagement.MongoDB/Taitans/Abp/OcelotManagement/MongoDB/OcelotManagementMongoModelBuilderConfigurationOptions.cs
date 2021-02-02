using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Taitans.OcelotManagement.MongoDB
{
    public class OcelotManagementMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public OcelotManagementMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}