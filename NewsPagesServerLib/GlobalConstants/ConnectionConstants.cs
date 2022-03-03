namespace NewsPagesServerLib.GlobalConstants
{
    internal static class ConnectionConstants
    {
        public const string ConnectionString = "server = " + Server + " port = " + Port + " database = "
            + Database + " user id = " + User + " password = " + Password;

        private const string Server = "localhost;";
        private const string Port = "5432;";
        private const string User = "postgres;";
        private const string Password = "Ivan;";
        private const string Database = "Pages;";
        private const string SslState = "None;";
    }
}
