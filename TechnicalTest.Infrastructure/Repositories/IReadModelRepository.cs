using TechnicalTest.Core;

namespace TechnicalTest.Infrastructure.Repositories
{
    public interface IReadModelRepository<T> where T : ReadModel
    {
        void Insert(T entity);
        Task<T?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
