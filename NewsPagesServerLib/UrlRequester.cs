using Abot2.Core;
using Abot2.Poco;

namespace NewsPagesServerLib
{
    internal class UrlRequester
    {
        private readonly string _url;

        public UrlRequester(string url)
        {
            _url = url;
        }

        public async Task<CrawledPage> GetPageInfo()
        {
            var pageRequester =
                new PageRequester(new CrawlConfiguration(), new WebContentExtractor());

            var result = await pageRequester.MakeRequestAsync(new Uri(_url));


            return result;
            /*Console.WriteLine(result.Content.Text);
            Console.WriteLine("End");
            Console.WriteLine(result.AngleSharpHtmlDocument.Title);*/
        }
    }
}
