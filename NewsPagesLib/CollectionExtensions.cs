namespace NewsPagesLib
{
    internal static class CollectionExtensions
    {
        public static IEnumerable<T> ConcatEntity<T>(this IEnumerable<IEnumerable<T>> entityByTypesName)
        {
            IEnumerable<T> zippedEntity = new List<T>();

            foreach (var slots in entityByTypesName)
            {
                zippedEntity = zippedEntity.Concat(slots);
            }

            return zippedEntity;
        }

        public static ICollection<T> AddEnumerable<T>(this ICollection<T> collection, IEnumerable<T> entitiesToAdd)
        {
            foreach (var entity in entitiesToAdd)
            {
                collection.Add(entity);
            }

            return collection;
        }
    }
}
