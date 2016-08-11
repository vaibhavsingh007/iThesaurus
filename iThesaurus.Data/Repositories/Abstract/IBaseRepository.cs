using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iThesaurus.Data.Repositories.Abstract
{
    public interface IBaseRepository<TEntity> : IDisposable
     where TEntity : class
    {
        void Delete(object id);
        void Delete(TEntity entity);
        TEntity Find(params object[] keyValues);
        TEntity Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        IQueryable<TEntity> SelectQuery(string query, params object[] parameters);
        void Update(TEntity entity);
        void RefreshEntityContext(TEntity entity);
    }
}
