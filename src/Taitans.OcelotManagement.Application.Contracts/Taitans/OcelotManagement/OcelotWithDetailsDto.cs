using System.Collections.Generic;

namespace Taitans.OcelotManagement
{
    public class OcelotWithDetailsDto : OcelotDtoBase
    {
        public List<OcelotRouteDto> OcelotRoutes { get; set; }
    }
}
