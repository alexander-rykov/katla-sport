using System.Collections.Generic;
using System.Linq;
using KatlaSport.DataAccess;

namespace KatlaSport.Services.Tests
{
    internal class FakeEntitySet<TEntity> : EntitySetBase<TEntity>
    where TEntity : class
    {
        private readonly IList<TEntity> _list;
        private readonly IQueryable<TEntity> _queryable;

        public FakeEntitySet(IList<TEntity> list)
        {
            _list = list;
            _queryable = list.AsQueryable();
        }

        protected override IQueryable<TEntity> Queryable => _queryable;

        public override TEntity Add(TEntity entity)
        {
            _list.Add(entity);
            return entity;
        }

        public override TEntity Remove(TEntity entity)
        {
            _list.Remove(entity);
            return entity;
        }
    }
}
