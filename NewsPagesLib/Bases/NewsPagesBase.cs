using NewsPagesLib.Tables;
using Pullenti.Ner;

namespace NewsPagesLib.Bases
{
    public class NewsPagesBase : IBaseTable<NewsPagesInfo>
    {
        public ICollection<NewsPagesInfo> NewsPages { get; }

        public NewsPagesBase(ICollection<NewsPagesInfo> newsPages)
        {
            NewsPages = newsPages;
        }

        public NewsPagesInfo GetById(int id)
        {
            return NewsPages.SingleOrDefault(newsPage => newsPage.Id == id);
        }

        public void Add(NewsPagesInfo entity)
        {
            entity.TryMakeOperation(() => NewsPages.Add(entity));
        }

        public void Remove(NewsPagesInfo entity)
        {
            entity.TryMakeOperation(() => NewsPages.Remove(entity));
        }

        public void Update(NewsPagesInfo oldData, NewsPagesInfo newData)
        {
            oldData.TryMakeOperation(() => NewsPages.Remove(oldData));
            newData.TryMakeOperation(() => NewsPages.Remove(newData));
        }

        public ICollection<string> FindByEntitiesNames(IEnumerable<string> textAttributes)
        {
            ICollection<string> foundEntites = new List<string>();

            foreach (var newsPage in NewsPages)
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
