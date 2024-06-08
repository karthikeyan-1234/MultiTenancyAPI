namespace DemoApplicationAPI
{
    public class TenantResolver : ITenantResolver
    {
        ITenantProvider tenantProvider;
        IHttpContextAccessor httpContextAccessor;

        public TenantResolver(IHttpContextAccessor httpContextAccessor, ITenantProvider tenantProvider)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.tenantProvider = tenantProvider;
        }

        public string? GetConnectionString()
        {
            string group = "US";
            var claims = httpContextAccessor?.HttpContext?.User.Claims!;

            foreach (var claim in claims)
            {
                if (claim.Type == "Group")
                    group = claim.Value;
            }

            return tenantProvider?.GetConnectionString(group);
        }
    }
}
