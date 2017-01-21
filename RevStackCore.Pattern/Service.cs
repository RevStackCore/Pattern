using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RevStackCore.Pattern
{
    public class Service<TEntity, TKey> : IService<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        protected readonly IRepository<TEntity, TKey> _repository;

        public Service(IRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return _repository.Get();
        }

		public virtual TEntity GetById(TKey id)
		{
			return _repository.GetById(id);
		}

        public virtual Task<IEnumerable<TEntity>> GetAsync()
        {
            return Task.FromResult(Get());
        }

		public virtual Task<TEntity> GetByIdAsync(TKey id)
		{
			return Task.FromResult(GetById(id));
		}

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Find(predicate);
        }

        public virtual Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(Find(predicate));
        }

        public virtual TEntity Add(TEntity entity)
        {
            return _repository.Add(entity);
        }

        public virtual Task<TEntity> AddAsync(TEntity entity)
        {
            return Task.FromResult(Add(entity));
        }

        public virtual TEntity Update(TEntity entity)
        {
            return _repository.Update(entity);
        }

        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.FromResult(Update(entity));
        }

        public virtual void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public virtual Task DeleteAsync(TEntity entity)
        {
            return Task.Run(() => Delete(entity));
        }
    }
}
