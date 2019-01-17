using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KatlaSport.DataAccess
{
    internal abstract class DomainContextBase<TDbContext>
        where TDbContext : DbContext
    {
        private readonly ApplicationDbContext _dbContext;
        private EntitySetCacheItem[] _entitySetCache;

        public DomainContextBase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            _entitySetCache = CreateEntitySetCache(dbContext);
        }

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken) => await _dbContext.SaveChangesAsync(cancellationToken);

        protected IEntitySet<TEntityType> GetDbSet<TEntityType>()
            where TEntityType : class
        {
            var index = Array.FindIndex(_entitySetCache, i => i.CacheKey == typeof(TEntityType));

            if (index < 0)
            {
                return null;
            }

            var cacheItem = _entitySetCache[index];

            if (cacheItem.EntitySet == null)
            {
                var constructedType = typeof(EntitySet<>).MakeGenericType(cacheItem.CacheKey);
                var entitySet = Activator.CreateInstance(constructedType, cacheItem.DbSet);
                cacheItem.EntitySet = entitySet;

                _entitySetCache[index] = cacheItem;
            }

            return cacheItem.EntitySet as IEntitySet<TEntityType>;
        }

        private static EntitySetCacheItem[] CreateEntitySetCache(ApplicationDbContext dbContext)
        {
            return TypeDescriptor
                .GetProperties(dbContext)
                .Cast<PropertyDescriptor>()
                .Where(p => p.PropertyType.IsConstructedGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .Select(p => new EntitySetCacheItem(p.PropertyType.GenericTypeArguments[0], p.GetValue(dbContext)))
                .ToArray();
        }

        private struct EntitySetCacheItem
        {
            public EntitySetCacheItem(Type cacheKey, object dbSet)
            {
                CacheKey = cacheKey;
                DbSet = dbSet;
                EntitySet = null;
            }

            public Type CacheKey { get; private set; }

            public object DbSet { get; private set; }

            public object EntitySet { get; set; }
        }
    }
}
