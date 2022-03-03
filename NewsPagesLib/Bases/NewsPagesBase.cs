using NewsPagesLib.Tables;
using Pullenti.Ner;

namespace NewsPagesLib.Bases
{
    public class NewsPagesBase : IBaseTable<NewsPagesInfo>
    {
        private readonly ICollection<NewsPagesInfo> _newsPages;

        public NewsPagesBase(ICollection<NewsPagesInfo> newsPages)
        {
            _newsPages = newsPages;
        }

        public void Add(NewsPagesInfo entity)
        {
            entity.TryMakeOperation(() => _newsPages.Add(entity));
        }

        public void Remove(NewsPagesInfo entity)
        {
            entity.TryMakeOperation(() => _newsPages.Remove(entity));
        }

        public void Update(NewsPagesInfo oldData, NewsPagesInfo newData)
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
