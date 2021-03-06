﻿using System;

namespace Taitans.OcelotManagement
{
    public class RouteQoSOption : QoSOptionBase
    {
        public virtual Guid GlobalConfigurationId { get; protected set; }
        public virtual string RouteName { get; protected set; }

        public RouteQoSOption(Guid globalConfigurationId, string routeName)
        {
            GlobalConfigurationId = globalConfigurationId;
            RouteName = routeName;
        }

        public override object[] GetKeys()
        {
            return new object[] { GlobalConfigurationId, RouteName };
        }
    }
}
