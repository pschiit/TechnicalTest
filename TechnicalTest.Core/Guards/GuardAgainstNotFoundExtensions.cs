using TechnicalTest.Core.Exceptions;

namespace TechnicalTest.Core.Guards;
public static partial class GuardClauseExtensions
{
    public static T NotFound<T>(this IGuardClause guardClause, T? aggregate, string? message = null)
        where T : class 
        => aggregate == null ?
            throw new NotFoundException(message ?? "not found") :
            aggregate!;
}