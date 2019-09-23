using System.Threading;
using System.Threading.Tasks;

namespace KatlaSport.DataAccess
{
    public interface IAsyncEntityStorage
    {
        Task<int> SaveChangesAsync();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
