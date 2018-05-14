using System;
using System.Collections.Generic;
using System.Linq;
using KatlaSport.DataAccess.CustomerCatalogue;

namespace KatlaSport.Services.CustomerManagement
{
    public class CustomerManagementService : ICustomerManagementService
    {
        private readonly ICustomerContext _context;

        public CustomerManagementService(ICustomerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int GetAmount()
        {
            return _context.Customers.Count();
        }

        public IList<CustomerBriefInfo> GetBriefInfo(int start, int amount)
        {
            return _context.Customers.Skip(start).Take(amount).Select(c => new CustomerBriefInfo
            {
                Id = c.Id,
                Name = c.Name
            }).ToArray();
        }

        public IList<CustomerFullInfo> GetFullInfo(IEnumerable<int> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            var idArray = ids.ToArray();
            return _context.Customers.Where(c => idArray.Contains(c.Id)).Select(c => new CustomerFullInfo
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                Phone = c.Phone
            }).ToArray();
        }
    }
}
