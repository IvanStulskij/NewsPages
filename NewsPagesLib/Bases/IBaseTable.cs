namespace NewsPagesLib.Bases
{
    internal interface IBaseTable<T>
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T oldData, T newData);
    }
}
