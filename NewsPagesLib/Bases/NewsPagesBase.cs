using NewsPagesLib.Tables;
using Pullenti.Ner;
using System.Text.RegularExpressions;

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

        public NewsPagesInfo GetByUrl(string url)
        {
            return NewsPages.FirstOrDefault(newsPage => newsPage.URL == url);
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

        public IEnumerable<NewsPagesInfo> FindByName(string name)
        {
            ICollection<NewsPagesInfo> searchedPages = new List<NewsPagesInfo>();

            foreach (var newsPage in NewsPages)
            {
                var regex = new Regex($@"(\w*){newsPage.Title}(\w*)");
                if (regex.Matches(name).Any())
                {
                    searchedPages.Add(newsPage);
                }
            }

            return searchedPages;
        }

        public ICollection<string> FindByEntitiesNames(NewsPagesInfo newsPage, string textAttribute)
        {
            ICollection<string> foundEntites = new List<string>();

            var entities = newsPage.GetEntities();

            var slots = GetEntitySlots(entities, textAttribute);

            return foundEntites.AddEnumerable(slots.ConcatEntity());

        }

        public ICollection<NewsPagesInfo> GetNewsPagesByEntities(string textAttribute)
        {
            ICollection<NewsPagesInfo> foundEntites = new List<NewsPagesInfo>();

            foreach (var newsPage in NewsPages)
            {
                var entities = newsPage.GetEntities();
                var slots = GetEntitySlots(entities, textAttribute).ConcatEntity();

                if (slots.Any())
                {
                    foundEntites.Add(newsPage);
                }
            }

            return foundEntites;
            
        }

        private IEnumerable<IEnumerable<string>> GetEntitySlots(IEnumerable<Referent> entities, string textAttribute)
        {
            return entities
                    .Where(entity => entity.TypeName.ToLower() == textAttribute.ToLower())
                    .Select(entity => entity.Slots)
                    .Select(slotsOfEntity => slotsOfEntity
                        .Select(slot => slot.Value.ToString()));
        }
    }
}
