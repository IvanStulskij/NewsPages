using NewsPagesLib.Tables;
using ServiceStack.OrmLite;

namespace NewsPagesServerLib.Bases
{
    public class NewsPagesDbBase : BaseDbTable<NewsPagesInfo>
    {
        private readonly Connection _connection;

        public NewsPagesDbBase(Connection connection) : base(connection)
        {
            _connection = connection;
        }

        public override void Insert(NewsPagesInfo value)
        {
            if (value != null)
            {
                value.Id = GetLastId() + 1;
                _connection.DbConnection.Insert(value);
            }
        }

        public void Insert(string Url)
        {
            if (!string.IsNullOrWhiteSpace(Url))
            {
                var requester = new UrlRequester(Url);
                var result = requester.GetPageInfo().Result;

                var value = new NewsPagesInfo()
                {
                    Id = GetLastId() + 1,
                    Title = result.AngleSharpHtmlDocument.Title,
                    Text = result.AngleSharpHtmlDocument.Body.TextContent,
                    URL = result.Uri.AbsoluteUri,
                    Text_html = result.Content.Text,
                    Date = DateTime.Now,
                };
                Console.WriteLine(value.Title);
                _connection.DbConnection.Insert(value);
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
