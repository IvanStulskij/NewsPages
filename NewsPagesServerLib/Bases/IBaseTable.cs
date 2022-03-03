namespace NewsPagesServerLib.Bases
{
    internal interface IBaseTable<T>
    {
        void SelectAll();
        void Update(T entity);
        void Delete(T entity);
        void Insert(T entity);
    }
}
