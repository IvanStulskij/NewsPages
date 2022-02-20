using NewsPagesLib.Tables;

namespace NewsPagesLib.Bases
{
    public class NewsPagesBase : IBaseTable<NewsPageInfo>
    {
        private readonly ICollection<NewsPageInfo> _newsPages;

        public NewsPagesBase(ICollection<NewsPageInfo> newsPages)
        {
            _newsPages = newsPages;
        }

        public void Add(NewsPageInfo entity)
        {
            _newsPages.Add(entity);
        }

        public void Remove(NewsPageInfo entity)
        {
            _newsPages.Remove(entity);
        }

        public void Update(NewsPageInfo oldData, NewsPageInfo newData)
        {
            _newsPages.Remove(oldData);
            _newsPages.Add(newData);
        }
    }
}
