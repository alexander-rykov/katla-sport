using System.Collections.Generic;

namespace KatlaSport.Services.CustomerManagement
{
    /// <summary>
    /// Represents a customer management service.
    /// </summary>
    public interface ICustomerManagementService
    {
        int GetAmount();

        IList<CustomerBriefInfo> GetBriefInfo(int start, int amount);

        IList<CustomerFullInfo> GetFullInfo(IEnumerable<int> ids);
    }
}
