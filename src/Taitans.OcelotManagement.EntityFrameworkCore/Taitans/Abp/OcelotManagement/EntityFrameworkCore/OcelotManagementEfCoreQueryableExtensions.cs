﻿using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Taitans.OcelotManagement.EntityFrameworkCore
{
    public static class OcelotManagementEfCoreQueryableExtensions
    {
        public static IQueryable<Ocelot> IncludeDetails(this IQueryable<Ocelot> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.ServiceDiscoveryProvider)
                .Include(x => x.RateLimitOption)
                .Include(x => x.QoSOption)
                .Include(x => x.LoadBalancerOption)
                .Include(x => x.HttpHandlerOption)
                .Include(x => x.Routes)
                    .ThenInclude(s => s.DelegatingHandlers)
                .Include(x => x.Routes)
                    .ThenInclude(s => s.DownstreamHostAndPorts)
                .Include(x => x.Routes)
                    .ThenInclude(s => s.HttpHandlerOption)
                .Include(x => x.Routes)
                    .ThenInclude(s => s.AuthenticationOption)
                        .ThenInclude(s => s.AllowedScopes)
                .Include(x => x.Routes)
                    .ThenInclude(s => s.RateLimitOption)
                        .ThenInclude(s => s.ClientWhitelist)
                .Include(x => x.Routes)
                    .ThenInclude(s => s.LoadBalancerOption)
                .Include(x => x.Routes)
                    .ThenInclude(s => s.QoSOption)
                .Include(x => x.Routes)
                    .ThenInclude(s => s.CacheOption)
                .Include(x => x.Routes)
                    .ThenInclude(s => s.UpstreamHttpMethods)
                .Include(x => x.Routes)
                    .ThenInclude(s => s.SecurityOption)
                //TODO: chcek generate sql.
                .Include(x => x.Routes)
                    .ThenInclude(s => s.SecurityOption)
                        .ThenInclude(s => s.IPAllowedList)
                .Include(x => x.Routes)
                    .ThenInclude(s => s.SecurityOption)
                        .ThenInclude(s => s.IPBlockedList);

        }

        public static IQueryable<OcelotRoute> IncludeDetails(this IQueryable<OcelotRoute> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(s => s.DelegatingHandlers)
                .Include(s => s.DownstreamHostAndPorts)
                .Include(s => s.HttpHandlerOption)
                .Include(s => s.AuthenticationOption)
                    .ThenInclude(s => s.AllowedScopes)
                .Include(s => s.RateLimitOption)
                    .ThenInclude(s => s.ClientWhitelist)
                .Include(s => s.LoadBalancerOption)
                .Include(s => s.QoSOption)
                .Include(s => s.CacheOption)
                .Include(s => s.UpstreamHttpMethods)
                .Include(s => s.SecurityOption)
                .Include(s => s.SecurityOption)
                    .ThenInclude(s => s.IPAllowedList)
                .Include(s => s.SecurityOption)
                    .ThenInclude(s => s.IPBlockedList);
        }
    }


}
