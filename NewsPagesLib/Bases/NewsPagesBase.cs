using NewsPagesLib.Tables;
using Pullenti.Ner;

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

        public ICollection<string> FindByEntitiesNames(IEnumerable<string> textAttributes)
        {
            ICollection<string> foundEntites = new List<string>();

            foreach (var newsPage in _newsPages)
            {
                var entities = newsPage.GetEntities();

                foreach (var textAttribute in textAttributes)
                {
                    var slots = GetEntitySlots(entities, textAttribute);

                    foundEntites.AddEnumerable(slots.ConcatEntity());
                }
            }

            return foundEntites;
        }

        private IEnumerable<IEnumerable<string>> GetEntitySlots(IEnumerable<Referent> entities, string textAttribute)
        {
            return entities
                    .Where(entity => entity.TypeName == textAttribute)
                    .Select(entity => entity.Slots)
                    .Select(slotsOfEntity => slotsOfEntity
                        .Select(slot => slot.Value.ToString()));
        }
    }
}
