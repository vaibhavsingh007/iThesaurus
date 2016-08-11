using iThesaurus.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace iThesaurus.Data.Repositories.Concrete
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        protected ThesaurusContext Context
        {
            get { return (ThesaurusContext)UnitOfWork; }
        }

        protected BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            UnitOfWork = unitOfWork;
        }

        protected virtual DbSet<TEntity> GetDbSet()
        {
            return this.Context.Set<TEntity>();
        }

        protected virtual void SetEntityState(object entity, EntityState entityState)
        {
            this.Context.Entry(entity).State = entityState;
        }

        public virtual TEntity Find(params object[] keyValues)
        {
            return GetDbSet().Find(keyValues);
        }

        public virtual IQueryable<TEntity> SelectQuery(string query, params object[] parameters)
        {
            return GetDbSet().SqlQuery(query, parameters).AsQueryable();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            TEntity retval;

            try
            {
                retval = GetDbSet().Add(entity);
                SaveContext();
            }
            catch (Exception)
            {
                throw;
            }

            return retval;
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                GetDbSet().Add(entity);
            }
            SaveContext();
        }

        public virtual void Update(TEntity entity)
        {
            GetDbSet().Attach(entity);
            SetEntityState(entity, EntityState.Modified);
            try
            {
                SaveContext();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void Delete(object id)
        {
            var entity = GetDbSet().Find(id);
            try
            {
                Delete(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            GetDbSet().Attach(entity);
            SetEntityState(entity, EntityState.Deleted);
            try
            {
                SaveContext();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void RefreshEntityContext(TEntity entity)
        {
            var context = ((IObjectContextAdapter)Context).ObjectContext;
            context.Refresh(RefreshMode.StoreWins, entity);
        }

        /// <summary>
        /// In order to handle Optimistic Concurrency.
        /// </summary>
        protected void SaveContext()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    UnitOfWork.SaveChanges();
                }
                catch (OptimisticConcurrencyException)
                {
                    saveFailed = true;
                    var context = ((IObjectContextAdapter)Context).ObjectContext;
                    context.Refresh(RefreshMode.StoreWins, typeof(TEntity));
                }
            } while (saveFailed);
        }

        /// <summary>
        /// For exceptional usage only.
        /// Eg. When instantiating explicit db context. 
        /// </summary>
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
