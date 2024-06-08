namespace DemoApplicationAPI
{
    public interface ITenantProvider
    {
        string? GetConnectionString(string group);
    }
}