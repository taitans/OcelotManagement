﻿using System;
using Volo.Abp.Domain.Entities;

namespace Taitans.OcelotManagement
{
    public class OcelotRateLimitOption : Entity
    {
        public virtual Guid GlobalConfigurationId { get; protected set; }
        public virtual string ClientIdHeader { get; set; }
        public virtual string QuotaExceededMessage { get; set; }
        public virtual string RateLimitCounterPrefix { get; set; }
        public virtual bool DisableRateLimitHeaders { get; set; }
        public virtual int HttpStatusCode { get; set; }

        public OcelotRateLimitOption(Guid globalConfigurationId)
        {
            GlobalConfigurationId = globalConfigurationId;
        }

        public override object[] GetKeys()
        {
            return new object[] { GlobalConfigurationId };
        }
    }
}