using ServiceStack.OrmLite;

namespace NewsPagesServerLib.Bases
{
    public abstract class BaseDbTable<T> : IBaseTable<T>
    {
        private readonly Connection _connection;

        public BaseDbTable(Connection connection)
        {
            _connection = connection;
        }

        public virtual IEnumerable<T> SelectAll()
        {
            return _connection.DbConnection.Select<T>();
        }

        public virtual void Insert(T value)
        {
            if (value != null)
            {
                _connection.DbConnection.Insert(value, selectIdentity: true);
            }
        }
        
        public virtual void Delete(T value)
        {
            if (value != null)
            {
                _connection.DbConnection.Delete(value);
            }
        }

        public virtual void Update(T value)
        {
            if (value != null)
            {
                _connection.DbConnection.Update(value);
            }
        }

        public void Update(T oldData, T newData)
        {
            if ((oldData != null) && (newData != null))
            {
                _connection.DbConnection.Delete(oldData);
                _connection.DbConnection.Insert(newData, true);
                
            }
        }

        public void DeleteById(int id)
        {
            if (id >= 0)
            {
                _connection.DbConnection.DeleteById<T>(id);
            }
        }
    }
}
