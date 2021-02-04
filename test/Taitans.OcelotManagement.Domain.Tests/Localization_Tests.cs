using Microsoft.Extensions.Localization;
using Shouldly;
using Taitans.OcelotManagement.Localization;
using Xunit;

namespace Taitans.OcelotManagement
{
    public class Localization_Tests : OcelotManagementDomainTestBase
    {
        private readonly IStringLocalizer<OcelotManagementResource> _stringLocalizer;

        public Localization_Tests()
        {
            _stringLocalizer = GetRequiredService<IStringLocalizer<OcelotManagementResource>>();
        }

        [Fact]
        public void Test()
        {
            _stringLocalizer["Permission:OcelotManagement"].Value.ShouldBe("Ocelot management");
        }
    }
}
