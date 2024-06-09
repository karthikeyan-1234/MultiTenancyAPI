API with MultiTenancy. Depending on the "group" of the user, the DB or SQL Server to be connected is decided. The connection strings are stored as encrypted values in appsettings.json 
and are decrypted during runtime. The encryption key is hardcoded into the application.
