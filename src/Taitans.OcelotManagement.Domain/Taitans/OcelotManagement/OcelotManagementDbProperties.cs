namespace Taitans.OcelotManagement
{
    public static class OcelotManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Ocelot";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "AbpOcelotManagement";
    }
}
