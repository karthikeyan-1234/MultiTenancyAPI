using DemoApplicationAPI.Models;

using Microsoft.Extensions.Configuration;

namespace DemoApplicationAPI
{
    public class TenantProvider : ITenantProvider
    {
        IConfiguration _configuration;

        public TenantProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? GetConnectionString(string group)
        {
            var tenants = _configuration.GetSection("Tenants").Get<IEnumerable<Tenant>>();
            return tenants.Where(t => t.Group == group).FirstOrDefault()?.ConnectionString;
        }
    }
}
