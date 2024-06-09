namespace DemoApplicationAPI
{
    public class TenantResolver : ITenantResolver
    {
        ITenantProvider tenantProvider;
        IHttpContextAccessor httpContextAccessor;
        ISQLSecurity sqlSecurity;

        public TenantResolver(IHttpContextAccessor httpContextAccessor, ITenantProvider tenantProvider, ISQLSecurity sqlSecurity)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.tenantProvider = tenantProvider;
            this.sqlSecurity = sqlSecurity;
        }

        public string? GetConnectionString()
        {
            string? group = null;
            var claims = httpContextAccessor?.HttpContext?.User.Claims!;

            foreach (var claim in claims)
            {
                if (claim.Type == "Group")
                    group = claim.Value;
            }

            string encryptedConnection = tenantProvider?.GetConnectionString(group!)!;
            string connection = sqlSecurity.DecryptConnection(encryptedConnection)!;

            connection = connection.Replace(@"\\", @"\");

            return connection;
        }
    }
}
