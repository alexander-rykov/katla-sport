using System.Data.Entity;
using System.Linq;

namespace KatlaSport.DataAccess
{
    internal class EntitySet<TEntity> : EntitySetBase<TEntity>
        where TEntity : class
    {
        public EntitySet(IDbSet<TEntity> dbSet)
        {
            DbSet = dbSet;
        }

        internal IDbSet<TEntity> DbSet { get; }

        protected override IQueryable<TEntity> Queryable => DbSet;

        public override TEntity Add(TEntity entity)
        {
            return DbSet.Add(entity);
        }

        public override TEntity Remove(TEntity entity)
        {
            return DbSet.Remove(entity);
        }
    }
}
