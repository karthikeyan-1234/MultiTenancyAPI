namespace DemoApplicationAPI
{
    public interface ISQLSecurity
    {
        string? DecryptConnection(string encryptedConnection);
        string? EncryptConnection(string connection);
    }
}