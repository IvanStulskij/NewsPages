namespace NewsPagesServerLib.Bases
{
    internal interface IBaseTable<T>
    {
        IEnumerable<T> SelectAll();
        void Update(T entity);
        void Delete(T entity);
        void Insert(T entity);
    }
}
