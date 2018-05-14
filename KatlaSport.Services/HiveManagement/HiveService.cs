using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        public List<HiveListItem> GetHives()
        {
            var dbHives = _context.Hives.OrderBy(h => h.Id).ToArray();
            var hives = dbHives.Select(h => Mapper.Map<HiveListItem>(h)).ToList();

            foreach (HiveListItem hive in hives)
            {
                hive.HiveSectionCount = _context.Sections.Where(s => s.StoreHiveId == hive.Id).Count();
            }

            return hives;
        }

        /// <inheritdoc/>
        public Hive GetHive(int hiveId)
        {
            var dbHives = _context.Hives.Where(h => h.Id == hiveId).ToArray();
            if (dbHives.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbHive, Hive>(dbHives[0]);
        }

        /// <inheritdoc/>
        public Hive CreateHive(UpdateHiveRequest createRequest)
        {
            var dbHives = _context.Hives.Where(h => h.Code == createRequest.Code).ToArray();
            if (dbHives.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            var dbHive = Mapper.Map<UpdateHiveRequest, DbHive>(createRequest);
            dbHive.CreatedBy = _userContext.UserId;
            dbHive.LastUpdatedBy = _userContext.UserId;
            _context.Hives.Add(dbHive);

            _context.SaveChanges();

            return Mapper.Map<Hive>(dbHive);
        }

        /// <inheritdoc/>
        public Hive UpdateHive(int hiveId, UpdateHiveRequest updateRequest)
        {
            var dbHives = _context.Hives.Where(p => p.Code == updateRequest.Code && p.Id != hiveId).ToArray();
            if (dbHives.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            dbHives = _context.Hives.Where(p => p.Id == hiveId).ToArray();
            if (dbHives.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbHive = dbHives[0];

            Mapper.Map(updateRequest, dbHive);
            dbHive.LastUpdatedBy = _userContext.UserId;

            _context.SaveChanges();

            return Mapper.Map<Hive>(dbHive);
        }

        /// <inheritdoc/>
        public void DeleteHive(int hiveId)
        {
            var dbHives = _context.Hives.Where(p => p.Id == hiveId).ToArray();
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
            _context.SaveChanges();
        }

        /// <inheritdoc/>
        public void SetStatus(int hiveId, bool deletedStatus)
        {
            throw new NotImplementedException();
        }
    }
}
