using NewsPagesLib.Tables;
using ServiceStack.OrmLite;

namespace NewsPagesServerLib.Bases
{
    public class NewsPageBase : BaseDbTable<NewsPagesInfo>
    {
        private readonly Connection _connection;

        public NewsPageBase(Connection connection) : base(connection)
        {
            _connection = connection;
        }

        public override void Insert(NewsPagesInfo value)
        {
            if (value != null)
            {
                value.Id = GetLastId() + 1;
                base.Insert(value);
            }
        }

        private int GetLastId()
        {
            return _connection.DbConnection
                .Select<NewsPagesInfo>()
                .Select(newsPage => newsPage.Id)
                .LastOrDefault();
        }
    }
}
