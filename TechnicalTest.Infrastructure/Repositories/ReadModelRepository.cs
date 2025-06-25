using Microsoft.EntityFrameworkCore;
using TechnicalTest.Core;

namespace TechnicalTest.Infrastructure.Repositories;

public class ReadModelRepository<T> : IReadModelRepository<T>
    where T : ReadModel
{
    private readonly BlogContext _context;
    private readonly DbSet<T> _entitySet;

    public ReadModelRepository(BlogContext context)
    {
        _context = context;
        _entitySet = _context.Set<T>();
    }
    public async Task<T?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _entitySet.FindAsync([id], cancellationToken);
    }

    public void Insert(T entity)
    {
        _entitySet.Add(entity);
    }
}
