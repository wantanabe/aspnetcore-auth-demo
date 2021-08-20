using System.Threading.Tasks;

namespace AuthDemo.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        Task SaveChangesAsync();
    }
}
