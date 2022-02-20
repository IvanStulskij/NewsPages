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
            entity.TryMakeOperation(() => _newsPages.Add(entity));
        }

        public void Remove(NewsPageInfo entity)
        {
            entity.TryMakeOperation(() => _newsPages.Remove(entity));
        }

        public void Update(NewsPageInfo oldData, NewsPageInfo newData)
        {
            oldData.TryMakeOperation(() => _newsPages.Remove(oldData));
            newData.TryMakeOperation(() => _newsPages.Remove(newData));
        }
    }
}
