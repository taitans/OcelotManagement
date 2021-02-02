using System.Collections.Generic;

namespace Taitans.OcelotManagement
{
    public class RouteAuthenticationOptionDto
    {
        public string AuthenticationProviderKey { get; set; }
        public List<string> AllowedScopes { get; set; }
    }
}