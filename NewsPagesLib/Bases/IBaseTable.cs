using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPagesLib.Bases
{
    internal interface IBaseTable<T>
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T oldData, T newData);

    }
}
