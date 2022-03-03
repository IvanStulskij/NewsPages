using NewsPagesLib.Tables;
using NewsPagesServerLib.GlobalConstants;
using ServiceStack.OrmLite;
using System.Data;

namespace NewsPagesServerLib
{
    public class Connection
    {
        private IDbConnection _dbConnection;
        public IDbConnection DbConnection 
        {
            get 
            {
                if (_dbConnection != null)
                {
                    return _dbConnection;
                }

                return DbFactory.Open();
            }
            set
            {
                _dbConnection = value;
            }
        }

        private OrmLiteConnectionFactory _dbFactory;
        private OrmLiteConnectionFactory DbFactory
        {
            get
            {
                if (_dbFactory != null)
                {
                    return _dbFactory;
                }

                return new OrmLiteConnectionFactory(
                ConnectionConstants.ConnectionString,
                PostgreSqlDialect.Provider);
            }
            set
            {
                _dbFactory = value;
            }
        }

        public IDbConnection Connect()
        {
            var dbFactory = new OrmLiteConnectionFactory(
                ConnectionConstants.ConnectionString,
                PostgreSqlDialect.Provider);

            return dbFactory.Open();
            /*int lastId = db.Select<NewsPagesInfo>()
                .Select(newsPage => newsPage.Id)
                .LastOrDefault();
            Console.WriteLine(lastId);
            db.Insert(new NewsPagesInfo
            {
                Id = lastId + 1,
                Date = new DateOnly(2008, 08, 13),
                Text = "Hello, thats Ivan Stulskiy",
                Text_html = "<html>Hello, thats Ivan Stulskiy</html>",
                URL = "https",
                Title = "Title"
            }) ;*/
        }
    }
}