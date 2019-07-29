using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductStoreHive;
using DbHive = KatlaSport.DataAccess.ProductStoreHive.StoreHive;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents a hive service.
    /// </summary>
    public class HiveService : IHiveService
    {
        private readonly IProductStoreHiveContext _context;
        private readonly IUserContext _userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="HiveService"/> class with specified <see cref="IProductStoreHiveContext"/> and <see cref="IUserContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IProductStoreHiveContext"/>.</param>
        /// <param name="userContext">A <see cref="IUserContext"/>.</param>
        public HiveService(IProductStoreHiveContext context, IUserContext userContext)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userContext = userContext ?? throw new ArgumentNullException();
        }

        /// <inheritdoc/>
        public async Task<List<HiveListItem>> GetHivesAsync()
        {
            var dbHives = await _context.Hives.OrderBy(h => h.Id).ToArrayAsync();
            var hives = dbHives.Select(h => Mapper.Map<HiveListItem>(h)).ToList();

            foreach (HiveListItem hive in hives)
            {
                hive.HiveSectionCount = _context.Sections.Where(s => s.StoreHiveId == hive.Id).Count();
            }

            return hives;
        }

        /// <inheritdoc/>
        public async Task<Hive> GetHiveAsync(int hiveId)
        {
            var dbHives = await _context.Hives.Where(h => h.Id == hiveId).ToArrayAsync();
            if (dbHives.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbHive, Hive>(dbHives[0]);
        }

        /// <inheritdoc/>
        public async Task<Hive> CreateHiveAsync(UpdateHiveRequest createRequest)
        {
            var dbHives = await _context.Hives.Where(h => h.Code == createRequest.Code).ToArrayAsync();
            if (dbHives.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            var dbHive = Mapper.Map<UpdateHiveRequest, DbHive>(createRequest);
            dbHive.CreatedBy = _userContext.UserId;
            dbHive.LastUpdatedBy = _userContext.UserId;
            _context.Hives.Add(dbHive);

            await _context.SaveChangesAsync();

            return Mapper.Map<Hive>(dbHive);
        }

        /// <inheritdoc/>
        public async Task<Hive> UpdateHiveAsync(int hiveId, UpdateHiveRequest updateRequest)
        {
            var dbHives = await _context.Hives.Where(p => p.Code == updateRequest.Code && p.Id != hiveId).ToArrayAsync();
            if (dbHives.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            dbHives = await _context.Hives.Where(p => p.Id == hiveId).ToArrayAsync();
            if (dbHives.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbHive = dbHives[0];

            Mapper.Map(updateRequest, dbHive);
            dbHive.LastUpdatedBy = _userContext.UserId;

            await _context.SaveChangesAsync();

            return Mapper.Map<Hive>(dbHive);
        }

        /// <inheritdoc/>
        public async Task DeleteHiveAsync(int hiveId)
        {
            var dbHives = await _context.Hives.Where(p => p.Id == hiveId).ToArrayAsync();
            if (dbHives.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbHive = dbHives[0];
            if (dbHive.IsDeleted == false)
            {
                throw new RequestedResourceHasConflictException();
            }

            _context.Hives.Remove(dbHive);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task SetStatusAsync(int hiveId, bool deletedStatus)
        {
            throw new NotImplementedException();
        }
    }
}
