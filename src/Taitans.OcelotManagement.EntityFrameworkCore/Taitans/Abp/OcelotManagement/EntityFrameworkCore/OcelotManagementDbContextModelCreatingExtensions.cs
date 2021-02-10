using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.EntityFrameworkCore.ValueComparers;
using Volo.Abp.EntityFrameworkCore.ValueConverters;

namespace Taitans.OcelotManagement.EntityFrameworkCore
{
    public static class OcelotManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureOcelotManagement(
            this ModelBuilder builder,
            Action<OcelotManagementModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new OcelotManagementModelBuilderConfigurationOptions(
                OcelotManagementDbProperties.DbTablePrefix,
                OcelotManagementDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            Check.NotNull(builder, nameof(builder));

            builder.Entity<Ocelot>(b =>
            {
                b.ToTable("Ocelots",
                         options.Schema);
                b.ConfigureFullAuditedAggregateRoot();

                b.Property(t => t.Name).IsRequired().HasMaxLength(OcelotConsts.NameMaxLength);

                b.HasOne(c => c.ServiceDiscoveryProvider).WithOne().HasForeignKey<OcelotServiceDiscoveryProvider>(r => new { r.GlobalConfigurationId }).OnDelete(DeleteBehavior.Cascade);

                b.HasOne(c => c.RateLimitOption).WithOne().HasForeignKey<OcelotRateLimitOption>(r => new { r.GlobalConfigurationId }).OnDelete(DeleteBehavior.Cascade);

                b.HasOne(c => c.QoSOption).WithOne().HasForeignKey<OcelotQoSOption>(r => new { r.GlobalConfigurationId }).OnDelete(DeleteBehavior.Cascade);

                b.HasOne(c => c.LoadBalancerOption).WithOne().HasForeignKey<OcelotLoadBalancerOption>(r => new { r.GlobalConfigurationId }).OnDelete(DeleteBehavior.Cascade);

                b.HasOne(c => c.HttpHandlerOption).WithOne().HasForeignKey<OcelotHttpHandlerOption>(r => new { r.GlobalConfigurationId }).OnDelete(DeleteBehavior.Cascade);

                b.HasMany(c => c.Routes).WithOne().HasForeignKey(c => c.GlobalConfigurationId).OnDelete(DeleteBehavior.Cascade);

                b.HasIndex(c => c.Name); //设置唯一
            });

            builder.Entity<OcelotRoute>(b =>
            {
                b.ToTable(OcelotManagementDbProperties.DbTablePrefix + "Routes",
                    OcelotManagementDbProperties.DbSchema);

                b.ConfigureByConvention();

                b.HasKey(x => new { x.GlobalConfigurationId, x.Name });
                 
                b.Property(t => t.AddQueriesToRequests)
                    .HasConversion(new AbpJsonValueConverter<Dictionary<string, string>>())
                    .Metadata.SetValueComparer(new StringDictionaryValueComparer<string, string>());

                b.Property(t => t.RouteClaimsRequirements)
                    .HasConversion(new AbpJsonValueConverter<Dictionary<string, string>>())
                    .Metadata.SetValueComparer(new StringDictionaryValueComparer<string, string>());

                b.Property(t => t.AddClaimsToRequests)
                    .HasConversion(new AbpJsonValueConverter<Dictionary<string, string>>())
                    .Metadata.SetValueComparer(new StringDictionaryValueComparer<string, string>());

                b.Property(t => t.DownstreamHeaderTransforms)
                    .HasConversion(new AbpJsonValueConverter<Dictionary<string, string>>())
                    .Metadata.SetValueComparer(new StringDictionaryValueComparer<string, string>());

                b.Property(t => t.UpstreamHeaderTransforms)
                    .HasConversion(new AbpJsonValueConverter<Dictionary<string, string>>())
                    .Metadata.SetValueComparer(new StringDictionaryValueComparer<string, string>());

                b.Property(t => t.AddHeadersToRequests)
                    .HasConversion(new AbpJsonValueConverter<Dictionary<string, string>>())
                    .Metadata.SetValueComparer(new StringDictionaryValueComparer<string, string>());

                b.Property(t => t.ChangeDownstreamPathTemplates)
                    .HasConversion(new AbpJsonValueConverter<Dictionary<string, string>>())
                    .Metadata.SetValueComparer(new StringDictionaryValueComparer<string, string>());
                 
                b.HasMany(c => c.DelegatingHandlers).WithOne().HasForeignKey(r => new { r.GlobalConfigurationId, r.RouteName }).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(c => c.DownstreamHostAndPorts).WithOne().HasForeignKey(r => new { r.GlobalConfigurationId, r.RouteName }).OnDelete(DeleteBehavior.Cascade).IsRequired();

                b.HasOne(c => c.HttpHandlerOption).WithOne().HasForeignKey<RouteHttpHandlerOption>(r => new { r.GlobalConfigurationId, r.RouteName }).OnDelete(DeleteBehavior.Cascade); 
                b.HasOne(c => c.AuthenticationOption).WithOne().HasForeignKey<RouteAuthenticationOption>(r => new { r.GlobalConfigurationId, r.RouteName }).OnDelete(DeleteBehavior.Cascade); 
                b.HasOne(c => c.RateLimitOption).WithOne().HasForeignKey<RouteRateLimitRule>(r => new { r.GlobalConfigurationId, r.RouteName }).OnDelete(DeleteBehavior.Cascade); 
                b.HasOne(c => c.LoadBalancerOption).WithOne().HasForeignKey<RouteLoadBalancerOption>(r => new { r.GlobalConfigurationId, r.RouteName }).OnDelete(DeleteBehavior.Cascade); 
                b.HasOne(c => c.QoSOption).WithOne().HasForeignKey<RouteQoSOption>(r => new { r.GlobalConfigurationId, r.RouteName }).OnDelete(DeleteBehavior.Cascade); 
                b.HasOne(c => c.CacheOption).WithOne().HasForeignKey<RouteCacheOption>(r => new { r.GlobalConfigurationId, r.RouteName }).OnDelete(DeleteBehavior.Cascade); 
                b.HasMany(c => c.UpstreamHttpMethods).WithOne().HasForeignKey(r => new { r.GlobalConfigurationId, r.RouteName }).OnDelete(DeleteBehavior.Cascade).IsRequired(); 
                b.HasOne(c => c.SecurityOption).WithOne().HasForeignKey<RouteSecurityOption>(r => new { r.GlobalConfigurationId, r.RouteName }).OnDelete(DeleteBehavior.Cascade);

                b.Property(t => t.Name).IsRequired().HasMaxLength(OcelotRouteConsts.NameMaxLength);
            });

            builder.Entity<RouteDelegatingHandler>(b =>
            {
                b.ToTable(options.TablePrefix + "RouteDelegatingHandler",
                    options.Schema);

                b.ConfigureByConvention();
                 
                b.HasKey(r => new { r.GlobalConfigurationId, r.RouteName, r.Delegating });

                b.Property(t => t.RouteName).IsRequired().HasMaxLength(RouteHttpHandlerOptionConsts.NameMaxLength); 
            });

            builder.Entity<RouteDownstreamHostAndPort>(b =>
            {
                b.ToTable(options.TablePrefix + "RouteDownstreamHostAndPorts",
                    options.Schema);

                b.ConfigureByConvention();

                b.HasKey(r => new { r.GlobalConfigurationId, r.RouteName, r.Host, r.Port });

                b.Property(t => t.RouteName).IsRequired().HasMaxLength(RouteHttpHandlerOptionConsts.NameMaxLength); 
            });

            builder.Entity<RouteHttpHandlerOption>(b =>
            {
                b.ToTable(options.TablePrefix + "RouteHttpHandlerOptions",
                    options.Schema);

                b.ConfigureByConvention();

                b.HasKey(r => new { r.GlobalConfigurationId, r.RouteName });

                b.Property(t => t.RouteName).IsRequired().HasMaxLength(RouteHttpHandlerOptionConsts.NameMaxLength); 
            });

            builder.Entity<RouteAuthenticationOptionAllowedScope>(b =>
            {
                b.ToTable(options.TablePrefix + "RouteAuthenticationOptionAllowedScope",
                    options.Schema);

                b.ConfigureByConvention();
                 
                b.HasKey(r => new { r.GlobalConfigurationId, r.RouteName, r.Scope });

                b.Property(t => t.RouteName).IsRequired().HasMaxLength(RouteAuthenticationOptionAllowedScopeConsts.NameMaxLength);
                b.Property(t => t.Scope).IsRequired().HasMaxLength(RouteAuthenticationOptionAllowedScopeConsts.ScopeMaxLength);

            });

            builder.Entity<RouteAuthenticationOption>(b =>
            {
                b.ToTable(options.TablePrefix + "RouteAuthenticationOptions",
                    options.Schema);

                b.ConfigureByConvention();

                b.HasKey(r => new { r.GlobalConfigurationId, r.RouteName }); 

                b.HasMany(r => r.AllowedScopes).WithOne().HasForeignKey(r => new { r.GlobalConfigurationId, r.RouteName }).OnDelete(DeleteBehavior.Cascade);

                b.Property(t => t.RouteName).IsRequired().HasMaxLength(RouteAuthenticationOptionConsts.NameMaxLength); 
            });
             
            builder.Entity<RouteRateLimitRule>(b =>
            {
                b.ToTable(options.TablePrefix + "RouteRateLimitRules",
                    options.Schema);

                b.ConfigureByConvention();

                b.HasKey(r => new { r.GlobalConfigurationId, r.RouteName });

                b.Property(t => t.RouteName).IsRequired().HasMaxLength(RouteRateLimitRuleConsts.NameMaxLength);
                 
                b.HasMany(r => r.ClientWhitelist).WithOne().HasForeignKey(r => new { r.GlobalConfigurationId, r.RouteName }).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<RouteRateLimitRuleClientWhitelist>(b =>
            {
                b.ToTable(options.TablePrefix + "RouteRateLimitRuleClientWhitelist",
                    options.Schema);

                b.Property(t => t.RouteName).IsRequired().HasMaxLength(RouteRateLimitRuleClientWhitelistConsts.NameMaxLength);

                b.HasKey(r => new { r.GlobalConfigurationId, r.RouteName, r.Whitelist });
            });

            builder.Entity<RouteLoadBalancerOption>(b =>
            {
                b.ToTable(options.TablePrefix + "RouteLoadBalancerOptions",
                    options.Schema);

                b.ConfigureByConvention(); 

                b.HasKey(r => new { r.GlobalConfigurationId, r.RouteName });

                b.Property(t => t.RouteName).IsRequired().HasMaxLength(RouteLoadBalancerOptionConsts.NameMaxLength); 
            });

            builder.Entity<RouteQoSOption>(b =>
            {
                b.ToTable(options.TablePrefix + "RouteQoSOptions",
                    options.Schema);

                b.ConfigureByConvention();
                 
                b.HasKey(r => new { r.GlobalConfigurationId, r.RouteName });

                b.Property(t => t.RouteName).IsRequired().HasMaxLength(RouteQoSOptionConsts.NameMaxLength); 
            });

            builder.Entity<RouteCacheOption>(b =>
            {
                b.ToTable(options.TablePrefix + "RouteCacheOptions",
                    options.Schema);

                b.ConfigureByConvention();

                b.HasKey(r => new { r.GlobalConfigurationId, r.RouteName });

                b.Property(t => t.RouteName).IsRequired().HasMaxLength(RouteCacheOptionConsts.NameMaxLength);  
            });

            builder.Entity<RouteUpstreamHttpMethod>(b =>
            {
                b.ToTable(OcelotManagementDbProperties.DbTablePrefix + "RouteUpstreamHttpMethods",
                   OcelotManagementDbProperties.DbSchema);

                b.ConfigureByConvention();

                b.HasKey(r => new { r.GlobalConfigurationId, r.RouteName, r.Method });

                b.Property(t => t.RouteName).IsRequired().HasMaxLength(RouteUpstreamHttpMethodConsts.NameMaxLength); 
            });

            builder.Entity<RouteSecurityOption>(b =>
            {
                b.ToTable(options.TablePrefix + "RouteSecurityOptions",
                    options.Schema);

                b.ConfigureByConvention();

                b.HasKey(r => new { r.GlobalConfigurationId, r.RouteName });
                 
                b.HasMany(r => r.IPAllowedList).WithOne().HasForeignKey(r => new { r.GlobalConfigurationId, r.RouteName }).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(r => r.IPBlockedList).WithOne().HasForeignKey(r => new { r.GlobalConfigurationId, r.RouteName }).OnDelete(DeleteBehavior.Cascade);
                 
                b.Property(t => t.RouteName).IsRequired().HasMaxLength(RouteSecurityOptionConsts.NameMaxLength);
            });

            builder.Entity<RouteSecurityOptionIPAllowed>(b =>
            {
                b.ToTable(options.TablePrefix + "RouteSecurityOptionIPAllowed",
                    options.Schema);

                b.ConfigureByConvention();

                b.HasKey(r => new { r.GlobalConfigurationId, r.RouteName, r.IP });

                b.Property(t => t.RouteName).IsRequired().HasMaxLength(RouteSecurityOptionIPAllowedConsts.NameMaxLength);
                b.Property(t => t.IP).IsRequired().HasMaxLength(RouteSecurityOptionIPAllowedConsts.IPMaxLength);
            });

            builder.Entity<RouteSecurityOptionIPBlocked>(b =>
            {
                b.ToTable(options.TablePrefix + "RouteSecurityOptionIPBlocked",
                    options.Schema);

                b.ConfigureByConvention();

                b.HasKey(r => new { r.GlobalConfigurationId, r.RouteName, r.IP });

                b.Property(t => t.RouteName).IsRequired().HasMaxLength(RouteSecurityOptionIPBlockedConsts.NameMaxLength);
                b.Property(t => t.IP).IsRequired().HasMaxLength(RouteSecurityOptionIPBlockedConsts.IPMaxLength);
            });
             
            builder.Entity<OcelotServiceDiscoveryProvider>(b =>
            {
                b.ToTable(options.TablePrefix + "ServiceDiscoveryProviders",
                   options.Schema);

                b.ConfigureByConvention();

                b.HasKey(r => new { r.GlobalConfigurationId });
            });

            builder.Entity<OcelotRateLimitOption>(b =>
            {
                b.ToTable(options.TablePrefix + "RateLimitOptions",
                   options.Schema);

                b.ConfigureByConvention();

                b.HasKey(r => new { r.GlobalConfigurationId });
            });

            builder.Entity<OcelotQoSOption>(b =>
            {
                b.ToTable(options.TablePrefix + "QoSOptions",
                   options.Schema);

                b.ConfigureByConvention();

                b.HasKey(r => new { r.GlobalConfigurationId });
            });

            builder.Entity<OcelotLoadBalancerOption>(b =>
            {
                b.ToTable(options.TablePrefix + "LoadBalancerOptions",
                   options.Schema);

                b.ConfigureByConvention();

                b.HasKey(r => new { r.GlobalConfigurationId });
            });
             
            builder.Entity<OcelotHttpHandlerOption>(b =>
            {
                b.ToTable(options.TablePrefix + "HttpHandlerOptions",
                    options.Schema);

                b.ConfigureByConvention();

                b.HasKey(r => new { r.GlobalConfigurationId });
            }); 
        }
    }
}