
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace UtilData
{
    public abstract class AbstractRepository<T> where T : class, new()
    {
        #region Instances
        protected Connection<T> connection = new Connection<T>();
        #endregion

        #region Public Metods
        public virtual long Insert(T t)
        {
            return GlobalConnection.Connection.Insert<T>(t);
        }

        public virtual bool Update(T t)
        {
            return GlobalConnection.Connection.Update<T>(t);
        }

        public virtual bool Delete(T t)
        {
            return GlobalConnection.Connection.Delete<T>(t);
        }

        public virtual List<T> GetAll()
        {
            return GlobalConnection.Connection.GetAll<T>().AsList();
        }

        public virtual T Get(int code)
        {
            return GlobalConnection.Connection.Get<T>(code);
        }
        #endregion
    }
}

