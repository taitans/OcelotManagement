﻿using System.Collections.Generic;

namespace Taitans.OcelotManagement
{
    public class RouteSecurityOptionDto
    {
        public List<string> IPAllowedList { get; set; }
        public List<string> IPBlockedList { get; set; }
    }
}